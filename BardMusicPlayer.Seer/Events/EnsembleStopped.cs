﻿/*
 * Copyright(c) 2022 MoogleTroupe
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

namespace BardMusicPlayer.Seer.Events;

public sealed class EnsembleStopped : SeerEvent
{
    internal EnsembleStopped(EventSource readerBackendType) : base(readerBackendType, 100)
    {
        EventType = GetType();
    }

    public override bool IsValid() => true;
}