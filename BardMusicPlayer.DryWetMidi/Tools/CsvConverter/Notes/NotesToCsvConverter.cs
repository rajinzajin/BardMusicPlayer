﻿using BardMusicPlayer.DryWetMidi.Interaction.LengthedObject;
using BardMusicPlayer.DryWetMidi.Interaction.Notes;
using BardMusicPlayer.DryWetMidi.Interaction.TempoMap;
using BardMusicPlayer.DryWetMidi.Interaction.TimedObject;
using BardMusicPlayer.DryWetMidi.Tools.CsvConverter.Common;

namespace BardMusicPlayer.DryWetMidi.Tools.CsvConverter.Notes;

internal static class NotesToCsvConverter
{
    #region Methods

    public static void ConvertToCsv(IEnumerable<Note> notes, Stream stream, TempoMap tempoMap, NoteCsvConversionSettings settings)
    {
        using (var csvWriter = new CsvWriter(stream, settings.CsvSettings))
        {
            foreach (var note in notes.Where(n => n != null))
            {
                csvWriter.WriteRecord(new[]
                {
                    note.TimeAs(settings.TimeType, tempoMap),
                    note.Channel,
                    NoteCsvConversionUtilities.FormatNoteNumber(note.NoteNumber, settings.NoteNumberFormat),
                    note.LengthAs(settings.NoteLengthType, tempoMap),
                    note.Velocity,
                    note.OffVelocity
                });
            }
        }
    }

    #endregion
}