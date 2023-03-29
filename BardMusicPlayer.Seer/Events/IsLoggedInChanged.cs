﻿/*
 * Copyright(c) 2023 MoogleTroupe
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

namespace BardMusicPlayer.Seer.Events;

public sealed class IsLoggedInChanged : SeerEvent
{
    internal IsLoggedInChanged(EventSource readerBackendType, bool status) : base(readerBackendType)
    {
        EventType  = GetType();
        IsLoggedIn = status;
    }

    public bool IsLoggedIn { get; }

    public override bool IsValid() => true;
}