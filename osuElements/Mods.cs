using System;

namespace osuElements
{
    [Flags]
    public enum Mods
    {
        None = 0,
        NoFail = 1,
        Easy = 2,
        Hidden = 8,
        HardRock = 16,
        SuddenDeath = 32,
        DoubleTime = 64,
        Relax = 128,
        HalfTime = 256,
        Nightcore = 512,
        Flashlight = 1024,
        Autoplay = 2048,
        SpunOut = 4096,
        Relax2 = 8192,
        Perfect = 16384,
        Key4 = 32768,
        Key5 = 65536,
        Key6 = 131072,
        Key7 = 262144,
        Key8 = 524288,
        FadeIn = 1048576,
        Random = 2097152,
        Cinema = 4194304,
        Target = 8388608,
        Key9 = 16777216,
        KeyCoop = 33554432,
        Key1 = 67108864,
        Key3 = 134217728,
        Key2 = 268435456,
        LastMod = 536870912,
        KeyMod = Key2 | Key3 | Key1 | KeyCoop | Key9 | Key8 | Key7 | Key6 | Key5 | Key4,
        // FreeModAllowed = KeyMod | FadeIn | Relax2 | SpunOut | Flashlight | Relax | SuddenDeath | HardRock | Hidden | Easy | NoFail,
        ScoreIncreaseMods = FadeIn | Flashlight | DoubleTime | HardRock | Hidden,
    }
    public static class ModsExtensions
    {
        public static double SpeedMultiplier(this Mods mods)
        {
            if ((mods & Mods.DoubleTime) > 0) return 1.5;
            return (mods & Mods.HalfTime) > 0 ? 0.75 : 1d;
        }
        public static string TwoCharacterString(this Mods mods)
        {
            var result = "";
            if (mods.HasFlag(Mods.NoFail)) result += "NF";
            if (mods.HasFlag(Mods.Easy)) result += "EZ";
            if (mods.HasFlag(Mods.Hidden)) result += "HD";
            if (mods.HasFlag(Mods.HardRock)) result += "HR";
            if (mods.HasFlag(Mods.SuddenDeath)) result += "SD";
            if (mods.HasFlag(Mods.DoubleTime)) result += "DT";
            if (mods.HasFlag(Mods.HalfTime)) result += "HT";
            if (mods.HasFlag(Mods.Nightcore)) result += "NC";
            if (mods.HasFlag(Mods.Flashlight)) result += "FL";
            if (mods.HasFlag(Mods.Perfect)) result += "PF";
            if (mods.HasFlag(Mods.Key1)) result += "1K";
            if (mods.HasFlag(Mods.Key2)) result += "2K";
            if (mods.HasFlag(Mods.Key3)) result += "3K";
            if (mods.HasFlag(Mods.Key4)) result += "4K";
            if (mods.HasFlag(Mods.Key5)) result += "5K";
            if (mods.HasFlag(Mods.Key6)) result += "6K";
            if (mods.HasFlag(Mods.Key7)) result += "7K";
            if (mods.HasFlag(Mods.Key8)) result += "8K";
            if (mods.HasFlag(Mods.Key9)) result += "9K";
            if (mods.HasFlag(Mods.KeyCoop)) result += ("CO");
            if (mods.HasFlag(Mods.FadeIn)) result += "FI";
            return result;
        }
    }
}