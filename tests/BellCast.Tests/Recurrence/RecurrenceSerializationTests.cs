using BellCast.Core.Recurrence;
using BellCast.Core.Serialization;

namespace BellCast.Tests.Recurrence;

public class RecurrenceSerializationTests
{
    [Fact]
    public void OneTime_round_trips()
    {
        RecurrenceSpec original = new OneTimeRecurrence(
            new DateTimeOffset(2026, 9, 3, 9, 0, 0, TimeSpan.FromHours(-4)));

        RoundTrip(original);
    }

    [Fact]
    public void Hourly_round_trips()
    {
        RecurrenceSpec original = new HourlyRecurrence(Minute: 30, Second: 0);
        RoundTrip(original);
    }

    [Fact]
    public void Daily_round_trips()
    {
        RecurrenceSpec original = new DailyRecurrence(new TimeOnly(8, 30));
        RoundTrip(original);
    }

    [Fact]
    public void Weekly_round_trips_with_weekdays_flag()
    {
        RecurrenceSpec original = new WeeklyRecurrence(
            DayOfWeekSet.Weekdays,
            new TimeOnly(8, 30));
        RoundTrip(original);
    }

    [Fact]
    public void DayOfMonth_round_trips()
    {
        RecurrenceSpec original = new DayOfMonthRecurrence(Day: 15, new TimeOnly(12, 0));
        RoundTrip(original);
    }

    [Fact]
    public void NthWeekdayOfMonth_round_trips()
    {
        RecurrenceSpec original = new NthWeekdayOfMonthRecurrence(
            N: 2,
            Weekday: DayOfWeek.Monday,
            Time: new TimeOnly(9, 0));
        RoundTrip(original);
    }

    [Fact]
    public void Annually_round_trips()
    {
        RecurrenceSpec original = new AnnuallyRecurrence(
            Month: 12,
            Day: 25,
            Time: new TimeOnly(0, 0));
        RoundTrip(original);
    }

    [Fact]
    public void Type_discriminator_is_present_in_payload()
    {
        RecurrenceSpec weekly = new WeeklyRecurrence(DayOfWeekSet.Monday, new TimeOnly(9, 0));

        string json = BellCastJson.Serialize(weekly);

        Assert.Contains("\"$type\":\"weekly\"", json);
    }

    [Fact]
    public void Deserialize_into_abstract_base_returns_concrete_variant()
    {
        const string json = """
            {"$type":"daily","time":"07:45:00"}
            """;

        var result = BellCastJson.Deserialize<RecurrenceSpec>(json);

        var daily = Assert.IsType<DailyRecurrence>(result);
        Assert.Equal(new TimeOnly(7, 45), daily.Time);
    }

    private static void RoundTrip(RecurrenceSpec original)
    {
        string json = BellCastJson.Serialize(original);
        var rehydrated = BellCastJson.Deserialize<RecurrenceSpec>(json);

        Assert.Equal(original, rehydrated);
        Assert.Equal(original.GetType(), rehydrated!.GetType());
    }
}
