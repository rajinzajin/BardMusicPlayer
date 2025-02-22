﻿/*
 * Copyright(c) 2022 GiR-Zippo
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

using System;

namespace BardMusicPlayer.Maestro.Old.Events;

public sealed class CurrentPlayPositionEvent : MaestroEvent
{
    internal CurrentPlayPositionEvent(TimeSpan inTimeSpan, int inTick)
    {
        EventType = GetType();
        timeSpan = inTimeSpan;
        tick = inTick;
    }

    public TimeSpan timeSpan { get; }

    public int tick { get; }

    public override bool IsValid() => true;
}