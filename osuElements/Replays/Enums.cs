using System;

namespace osuElements.Replays
{
    [Flags]
    public enum ReplayKeys
    {
        None = 0,
        M1 = 1,
        M2 = 2,
        K1 = 4,
        K2 = 8,
        Smoke = 16,
    }

    [Flags]
    public enum ManiaKeys
    {
        None,
        K1 = 1,
        K2 = 2,
        K3 = 4,
        K4 = 8,
        K5 = 16,
        K6 = 32,
        K7 = 64,
        K8 = 128,
        K9 = 256,
    }
}