﻿#region

using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using BardMusicPlayer.DryWetMidi.Common.DataTypes;
using BardMusicPlayer.DryWetMidi.Core;
using BardMusicPlayer.DryWetMidi.Core.Chunks;
using BardMusicPlayer.DryWetMidi.Core.Events.Channel;
using BardMusicPlayer.DryWetMidi.Core.Events.Meta;
using BardMusicPlayer.DryWetMidi.Interaction.TempoMap;
using BardMusicPlayer.DryWetMidi.Interaction.TimedEvents;
using BardMusicPlayer.DryWetMidi.Interaction.TimedObject;
using BardMusicPlayer.Quotidian.Structs;
using Newtonsoft.Json;

#endregion

namespace BardMusicPlayer.Transmogrify.Song.Importers;

public static class MMSongImporter
{
    /// <summary>
    ///     Opens and process a mmsong file
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static MidiFile OpenMMSongFile(string path)
    {
        if (!File.Exists(path)) throw new BmpTransmogrifyException("File " + path + " does not exist!");

        MMSongContainer songContainer = null;

        var fileToDecompress = new FileInfo(path);
        using (var originalFileStream = fileToDecompress.OpenRead())
        {
            var currentFileName = fileToDecompress.FullName;
            var newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
            using (var decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
            {
                using (var memoryStream = new MemoryStream())
                {
                    decompressionStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    var data = "";
                    using (var reader = new StreamReader(memoryStream, Encoding.ASCII))
                    {
                        while (reader.ReadLine() is { } line) data += line;
                    }

                    memoryStream.Close();
                    decompressionStream.Close();
                    songContainer = JsonConvert.DeserializeObject<MMSongContainer>(data);
                }
            }
        }

        var midiFile = new MidiFile();
        foreach (var mmsong in songContainer.songs)
            if (!mmsong.bards.Any())
            {
            }
            else
            {
                foreach (var bard in mmsong.bards)
                {
                    var thisTrack =
                        new TrackChunk(new SequenceTrackNameEvent(Instrument.Parse(bard.instrument).Name));
                    using (var manager = new TimedObjectsManager<TimedEvent>(thisTrack.Events))
                    {
                        var timedEvents = manager.Objects;
                        var last = 0;
                        foreach (var note in bard.sequence)
                            if (note.Value == 254)
                            {
                                var pitched = last + 24;
                                timedEvents.Add(new TimedEvent(
                                    new NoteOffEvent((SevenBitNumber)pitched, (SevenBitNumber)127), note.Key));
                            }
                            else
                            {
                                var pitched = (SevenBitNumber)note.Value + 24;
                                timedEvents.Add(new TimedEvent(
                                    new NoteOnEvent((SevenBitNumber)pitched, (SevenBitNumber)127), note.Key));
                                last = note.Value;
                            }
                    }

                    midiFile.Chunks.Add(thisTrack);
                }

                foreach (var lyrics in mmsong.lyrics)
                {
                    var thisTrack = new TrackChunk(new SequenceTrackNameEvent("Lyrics: " + lyrics.description));
                    using (var manager = new TimedObjectsManager<TimedEvent>(thisTrack.Events))
                    {
                        var timedEvents = manager.Objects;
                        foreach (var seqData in lyrics.sequence)
                        {
                            var f = lyrics.lines[seqData.Value];
                            f = f.Replace("/s ", "");
                            timedEvents.Add(
                                new TimedEvent(new LyricEvent(lyrics.lines[seqData.Value]), seqData.Key));
                        }
                    }

                    midiFile.Chunks.Add(thisTrack);
                }

                break; //Only the first song for now
            }

        midiFile.ReplaceTempoMap(TempoMap.Create(Tempo.FromBeatsPerMinute(25)));
        return midiFile;
    }
}