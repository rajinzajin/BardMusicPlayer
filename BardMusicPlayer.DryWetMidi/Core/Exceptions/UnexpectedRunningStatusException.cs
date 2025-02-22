﻿using BardMusicPlayer.DryWetMidi.Common;

namespace BardMusicPlayer.DryWetMidi.Core.Exceptions;

/// <summary>
/// The exception that is thrown when the reading engine encountered unexpected running
/// status.
/// </summary>
[Serializable]
public sealed class UnexpectedRunningStatusException : MidiException
{
    #region Constructors

    internal UnexpectedRunningStatusException()
        : base("Unexpected running status is encountered.")
    {
    }

    #endregion
}