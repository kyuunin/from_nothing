using System;

public static class DamageValues
{
    private const int DefaultLivesOfPlayer = 3;

    public static readonly TimeSpan PlayerIsSafeTimeSpan = TimeSpan.FromSeconds(3);

    public static int LivesOfPlayer { get; set; } = DefaultLivesOfPlayer;
    public static DateTime? PlayerIsSafeStartTime { get; set; } = null;
}
