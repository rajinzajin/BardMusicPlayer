﻿using System.IO;
using BardMusicPlayer.Maestro.Old;
using BardMusicPlayer.Transmogrify.Song;
using BardMusicPlayer.Transmogrify.Song.Config;
using Microsoft.Win32;

namespace BardMusicPlayer.Functions;

public static class PlaybackFunctions
{
    /// <summary>
    /// The playback states
    /// </summary>
    public enum PlaybackStateEnum
    {
        PlaybackStateStopped = 0,
        PlaybackStatePlaying,
        PlaybackStatePause,
        PlaybackStatePlayNext
    }

    internal static PlaybackStateEnum PlaybackState;

    /// <summary>
    /// The currently loaded song
    /// </summary>
    public static BmpSong? CurrentSong { get; private set; }

    /// <summary>
    /// Loads a midi file into the sequencer
    /// </summary>
    /// <returns>true if success</returns>
    public static bool LoadSong()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = Globals.Globals.DirectoryPath,
            Filter           = Globals.Globals.FileFilters,
            Multiselect      = true
        };

        if (openFileDialog.ShowDialog() != true)
            return false;

        if (!openFileDialog.CheckFileExists)
            return false;

        PlaybackState = PlaybackStateEnum.PlaybackStateStopped;

        Globals.Globals.DirectoryPath = Path.GetDirectoryName(openFileDialog.FileName);

        CurrentSong = BmpSong.OpenFile(openFileDialog.FileName).Result;
        BmpMaestro.Instance.SetSong(CurrentSong);
        return true;
    }

    /// <summary>
    /// Loads a midi file into the sequencer
    /// </summary>
    /// <returns>true if success</returns>
    public static bool LoadSong(string? filename)
    {
        if (!File.Exists(filename))
            return false;

        PlaybackState = PlaybackStateEnum.PlaybackStateStopped;

        CurrentSong = BmpSong.OpenFile(filename).Result;
        BmpMaestro.Instance.SetSong(CurrentSong);
        return true;
    }

    /// <summary>
    /// Load a song from the playlist into the sequencer
    /// </summary>
    /// <param name="item"></param>
    public static void LoadSongFromPlaylist(BmpSong? item)
    {
        PlaybackState = PlaybackStateEnum.PlaybackStateStopped;
        CurrentSong   = item;
        BmpMaestro.Instance.SetSong(CurrentSong);
    }

    /// <summary>
    /// Starts the performance
    /// </summary>
    public static void PlaySong(int delay)
    {
        PlaybackState = PlaybackStateEnum.PlaybackStatePlaying;
        BmpMaestro.Instance.StartLocalPerformer(delay);
    }

    /// <summary>
    /// Pause the performance
    /// </summary>
    public static void PauseSong()
    {
        PlaybackState = PlaybackStateEnum.PlaybackStatePause;
        BmpMaestro.Instance.PauseLocalPerformer();
    }

    /// <summary>
    /// Stops the performance
    /// </summary>
    public static void StopSong()
    {
        PlaybackState = PlaybackStateEnum.PlaybackStateStopped;
        BmpMaestro.Instance.StopLocalPerformer();
    }

    /// <summary>
    /// Gets the song name from the current song
    /// </summary>
    /// <returns>song name as string</returns>
    public static string GetSongName()
    {
        return CurrentSong == null ? "please load a song" : CurrentSong.Title;
    }

    /// <summary>
    /// Gets the instrument from the current song and track
    /// </summary>
    /// <returns>instrument name as string</returns>
    public static string GetInstrumentNameForHostPlayer()
    {
        var trackNumber = BmpMaestro.Instance.GetHostBardTrack();
        if (trackNumber == 0)
            return "All Tracks";
        if (CurrentSong == null)
            return "No song loaded";
        if (trackNumber > CurrentSong.TrackContainers.Count)
            return "None";
        try
        {
            var classicConfig = (ClassicProcessorConfig)CurrentSong.TrackContainers[trackNumber -1].ConfigContainers[0].ProcessorConfig; // track -1 cuz track 0 isn't in this container
            return classicConfig.Instrument.Name;
        }
        catch (KeyNotFoundException)
        {
            return "Unknown";
        }
    }

    /// <summary>
    /// Gets the instrument name from a given song and track
    /// </summary>
    /// <param name="song"></param>
    /// <param name="trackNumber"></param>
    /// <returns>instrument name as string</returns>
    public static string GetInstrumentName(BmpSong? song, int trackNumber)
    {
        if (trackNumber == 0)
            return "All Tracks";
        if (song == null)
            return "No song loaded";
        if (CurrentSong != null && trackNumber > CurrentSong.TrackContainers.Count)
            return "None";
        try
        {
            var classicConfig = (ClassicProcessorConfig)song.TrackContainers[trackNumber-1].ConfigContainers[0].ProcessorConfig;
            return classicConfig.Instrument.Name;
        }
        catch (KeyNotFoundException)
        {
            return "Unknown";
        }
    }
}