using BellCast.Core.Models;
using BellCast.Core.Serialization;

namespace BellCast.Tests.Models;

public class AppSettingsTests
{
    [Fact]
    public void Default_has_system_theme_and_standard_ntp_servers()
    {
        var defaults = AppSettings.Default;

        Assert.Equal(ThemePreference.System, defaults.Theme);
        Assert.False(defaults.StartWithWindows);
        Assert.Contains("pool.ntp.org", defaults.NtpServers);
        Assert.Contains("time.nist.gov", defaults.NtpServers);
        Assert.Null(defaults.DefaultOutputDeviceId);
        Assert.False(defaults.AutoSyncEnabled);
        Assert.Null(defaults.AutoSyncTime);
    }

    [Fact]
    public void AppSettings_round_trips_with_theme_enum_as_string()
    {
        var settings = new AppSettings(
            Theme: ThemePreference.Dark,
            StartWithWindows: true,
            NtpServers: new[] { "pool.ntp.org" },
            DefaultOutputDeviceId: "device-1",
            AutoSyncEnabled: true,
            AutoSyncTime: new TimeOnly(3, 0));

        string json = BellCastJson.Serialize(settings);
        var rehydrated = BellCastJson.Deserialize<AppSettings>(json);

        Assert.Contains("\"Dark\"", json);
        Assert.NotNull(rehydrated);
        Assert.Equal(settings with { NtpServers = Array.Empty<string>() },
                     rehydrated! with { NtpServers = Array.Empty<string>() });
        Assert.Equal(settings.NtpServers, rehydrated.NtpServers);
    }
}
