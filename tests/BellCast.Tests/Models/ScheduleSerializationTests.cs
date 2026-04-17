using BellCast.Core.Models;
using BellCast.Core.Recurrence;
using BellCast.Core.Serialization;

namespace BellCast.Tests.Models;

public class ScheduleSerializationTests
{
    [Fact]
    public void Full_schedule_round_trips()
    {
        var now = new DateTimeOffset(2026, 4, 17, 10, 0, 0, TimeSpan.Zero);
        var schedule = new Schedule(
            Id: Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name: "Morning Bell",
            Enabled: true,
            SoundFileId: Guid.Parse("22222222-2222-2222-2222-222222222222"),
            OutputDeviceId: "{0.0.0.00000000}.{abcd-1234}",
            Recurrence: new WeeklyRecurrence(DayOfWeekSet.Weekdays, new TimeOnly(8, 30)),
            ExclusionSetIds: new[]
            {
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
            },
            FadeInMs: 250,
            FadeOutMs: 500,
            Loop: false,
            CreatedAt: now,
            UpdatedAt: now);

        string json = BellCastJson.Serialize(schedule);
        var rehydrated = BellCastJson.Deserialize<Schedule>(json);

        Assert.NotNull(rehydrated);
        Assert.Equal(schedule with { ExclusionSetIds = Array.Empty<Guid>() },
                     rehydrated! with { ExclusionSetIds = Array.Empty<Guid>() });
        Assert.Equal(schedule.ExclusionSetIds, rehydrated.ExclusionSetIds);
    }

    [Fact]
    public void SoundFile_round_trips()
    {
        var sound = new SoundFile(
            Id: Guid.NewGuid(),
            DisplayName: "Classic Bell",
            RelativePath: "sounds/classic-bell.mp3",
            ImportedAt: new DateTimeOffset(2026, 4, 17, 10, 0, 0, TimeSpan.Zero),
            DurationMs: 3200,
            Format: "mp3");

        string json = BellCastJson.Serialize(sound);
        var rehydrated = BellCastJson.Deserialize<SoundFile>(json);

        Assert.Equal(sound, rehydrated);
    }
}
