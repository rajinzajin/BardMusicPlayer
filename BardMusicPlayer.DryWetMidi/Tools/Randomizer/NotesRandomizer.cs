﻿using BardMusicPlayer.DryWetMidi.Interaction.Notes;
using BardMusicPlayer.DryWetMidi.Tools.Randomizer.LengthedObjectsRandomizer;

namespace BardMusicPlayer.DryWetMidi.Tools.Randomizer;

/// <summary>
/// Settings according to which notes should be randomized.
/// </summary>
[Obsolete("OBS10")]
public sealed class NotesRandomizingSettings : LengthedObjectsRandomizingSettings<Note>
{
    #region Properties

    /// <summary>
    /// Gets or sets settings which define how notes should be detected and built.
    /// </summary>
    public NoteDetectionSettings NoteDetectionSettings { get; set; } = new NoteDetectionSettings();

    #endregion
}

/// <summary>
/// Provides methods to randomize notes time.
/// </summary>
[Obsolete("OBS10")]
public sealed class NotesRandomizer : LengthedObjectsRandomizer<Note, NotesRandomizingSettings>
{
}