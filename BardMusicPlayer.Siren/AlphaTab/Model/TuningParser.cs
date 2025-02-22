﻿/*
 * Copyright(c) 2021 Daniel Kuschny
 * Licensed under the MPL-2.0 license. See https://github.com/CoderLine/alphaTab/blob/develop/LICENSE for full license information.
 */

using System.Linq;

namespace BardMusicPlayer.Siren.AlphaTab.Model;

internal class TuningParseResult
{
    public string Note { get; set; }
    public int NoteValue { get; set; }
    public int Octave { get; set; }

    public int RealValue => Octave * 12 + NoteValue;
}

internal static class TuningParser
{
    /// <summary>
    /// Checks if the given string is a tuning indicator.
    /// </summary>Checks if the given string is a tuning indicator.
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool IsTuning(string name)
    {
        return Parse(name) != null;
    }

    public static TuningParseResult Parse(string name)
    {
        var note = "";
        var octave = "";

        foreach (var c in name.Select(t => (int)t))
        {
            if (Platform.IsCharNumber(c, false))
            {
                // number without note?
                if (string.IsNullOrEmpty(note))
                {
                    return null;
                }

                octave += Platform.StringFromCharCode(c);
            }
            else if (c is >= 0x41 and <= 0x5A or >= 0x61 and <= 0x7A or 0x23)
            {
                note += Platform.StringFromCharCode(c);
            }
            else
            {
                return null;
            }
        }

        if (string.IsNullOrEmpty(octave) || string.IsNullOrEmpty(note))
        {
            return null;
        }

        var result = new TuningParseResult
        {
            Octave = Platform.ParseInt(octave) + 1,
            Note   = note.ToLower()
        };
        result.NoteValue = GetToneForText(result.Note);
        return result;
    }

    public static int GetTuningForText(string str)
    {
        var result = Parse(str);
        if (result == null)
        {
            return -1;
        }

        return result.RealValue;
    }

    public static int GetToneForText(string note)
    {
        int b;
        switch (note.ToLower())
        {
            case "c":
                b = 0;
                break;
            case "c#":
            case "db":
                b = 1;
                break;
            case "d":
                b = 2;
                break;
            case "d#":
            case "eb":
                b = 3;
                break;
            case "e":
                b = 4;
                break;
            case "f":
                b = 5;
                break;
            case "f#":
            case "gb":
                b = 6;
                break;
            case "g":
                b = 7;
                break;
            case "g#":
            case "ab":
                b = 8;
                break;
            case "a":
                b = 9;
                break;
            case "a#":
            case "bb":
                b = 10;
                break;
            case "b":
                b = 11;
                break;
            default:
                return 0;
        }

        return b;
    }
}