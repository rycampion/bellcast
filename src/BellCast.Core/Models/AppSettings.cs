namespace BellCast.Core.Models;

public enum ThemePreference
{
    System = 0,
    Light = 1,
    Dark = 2,
}

public sealed record AppSettings(
    ThemePreference Theme,
    bool StartWithWindows,
    IReadOnlyList<string> NtpServers,
    string? DefaultOutputDeviceId,
    bool AutoSyncEnabled,
    TimeOnly? AutoSyncTime)
{
    public static AppSettings Default { get; } = new(
        Theme: ThemePreference.System,
        StartWithWindows: false,
        NtpServers: new[] { "pool.ntp.org", "time.nist.gov" },
        DefaultOutputDeviceId: null,
        AutoSyncEnabled: false,
        AutoSyncTime: null);
}
