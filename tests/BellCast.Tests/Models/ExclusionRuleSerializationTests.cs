using BellCast.Core.Models;
using BellCast.Core.Serialization;

namespace BellCast.Tests.Models;

public class ExclusionRuleSerializationTests
{
    [Fact]
    public void SpecificDate_round_trips()
    {
        ExclusionRule rule = new SpecificDateRule(new DateOnly(2026, 12, 25));
        RoundTrip(rule);
    }

    [Fact]
    public void DateRange_round_trips()
    {
        ExclusionRule rule = new DateRangeRule(
            new DateOnly(2026, 6, 28),
            new DateOnly(2026, 9, 2));
        RoundTrip(rule);
    }

    [Fact]
    public void Weekday_round_trips()
    {
        ExclusionRule rule = new WeekdayRule(DayOfWeek.Sunday);
        RoundTrip(rule);
    }

    [Fact]
    public void TimeWindow_round_trips()
    {
        ExclusionRule rule = new TimeWindowRule(
            new TimeOnly(12, 0),
            new TimeOnly(13, 0));
        RoundTrip(rule);
    }

    [Fact]
    public void ExclusionSet_with_mixed_rules_round_trips()
    {
        var set = new ExclusionSet(
            Id: Guid.NewGuid(),
            Name: "School Holidays 2026",
            Rules: new ExclusionRule[]
            {
                new DateRangeRule(new DateOnly(2026, 6, 28), new DateOnly(2026, 9, 2)),
                new SpecificDateRule(new DateOnly(2026, 12, 25)),
                new WeekdayRule(DayOfWeek.Saturday),
                new WeekdayRule(DayOfWeek.Sunday),
            });

        string json = BellCastJson.Serialize(set);
        var rehydrated = BellCastJson.Deserialize<ExclusionSet>(json);

        Assert.NotNull(rehydrated);
        Assert.Equal(set.Id, rehydrated!.Id);
        Assert.Equal(set.Name, rehydrated.Name);
        Assert.Equal(set.Rules.Count, rehydrated.Rules.Count);
        for (int i = 0; i < set.Rules.Count; i++)
            Assert.Equal(set.Rules[i], rehydrated.Rules[i]);
    }

    private static void RoundTrip(ExclusionRule original)
    {
        string json = BellCastJson.Serialize(original);
        var rehydrated = BellCastJson.Deserialize<ExclusionRule>(json);

        Assert.Equal(original, rehydrated);
        Assert.Equal(original.GetType(), rehydrated!.GetType());
    }
}
