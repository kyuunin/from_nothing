using System;

public static class DamageValues
{
    public static readonly TimeSpan PlayerIsSafeTimeSpan = TimeSpan.FromSeconds(3);

    public static int LifeOfPlayer { get; set; } = 3;
    public static DateTime? PlayerIsSafeStartTime { get; set; } = null;
}
