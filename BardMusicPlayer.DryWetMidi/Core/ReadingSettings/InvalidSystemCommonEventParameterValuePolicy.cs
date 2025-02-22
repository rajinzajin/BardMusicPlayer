﻿using BardMusicPlayer.DryWetMidi.Core.Events.SystemCommon;
using BardMusicPlayer.DryWetMidi.Core.Exceptions;

namespace BardMusicPlayer.DryWetMidi.Core.ReadingSettings;

/// <summary>
/// Specifies how reading engine should react on invalid value of a system common event's
/// parameter value. For example, <c>255</c> is the invalid value for the <see cref="SongSelectEvent.Number"/>
/// and will be processed according with this policy. The default is <see cref="Abort"/>.
/// </summary>
public enum InvalidSystemCommonEventParameterValuePolicy
{
    /// <summary>
    /// Abort reading and throw an <see cref="InvalidSystemCommonEventParameterValueException"/>.
    /// </summary>
    Abort = 0,

    /// <summary>
    /// Read value and snap it to limits of the allowable range if it is out of them.
    /// </summary>
    SnapToLimits
}