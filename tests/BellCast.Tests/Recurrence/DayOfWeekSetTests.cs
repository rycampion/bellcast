using BellCast.Core.Recurrence;

namespace BellCast.Tests.Recurrence;

public class DayOfWeekSetTests
{
    [Fact]
    public void Weekdays_contains_Mon_through_Fri()
    {
        var set = DayOfWeekSet.Weekdays;

        Assert.True(set.Contains(DayOfWeek.Monday));
        Assert.True(set.Contains(DayOfWeek.Tuesday));
        Assert.True(set.Contains(DayOfWeek.Wednesday));
        Assert.True(set.Contains(DayOfWeek.Thursday));
        Assert.True(set.Contains(DayOfWeek.Friday));
        Assert.False(set.Contains(DayOfWeek.Saturday));
        Assert.False(set.Contains(DayOfWeek.Sunday));
    }

    [Fact]
    public void Weekend_contains_Sat_and_Sun_only()
    {
        var set = DayOfWeekSet.Weekend;

        Assert.True(set.Contains(DayOfWeek.Saturday));
        Assert.True(set.Contains(DayOfWeek.Sunday));
        Assert.False(set.Contains(DayOfWeek.Monday));
    }

    [Fact]
    public void EveryDay_contains_all_seven()
    {
        var set = DayOfWeekSet.EveryDay;

        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            Assert.True(set.Contains(day), $"expected {day} in EveryDay");
    }

    [Fact]
    public void None_contains_no_days()
    {
        var set = DayOfWeekSet.None;

        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            Assert.False(set.Contains(day), $"did not expect {day} in None");
    }

    [Theory]
    [InlineData(DayOfWeek.Sunday, DayOfWeekSet.Sunday)]
    [InlineData(DayOfWeek.Monday, DayOfWeekSet.Monday)]
    [InlineData(DayOfWeek.Tuesday, DayOfWeekSet.Tuesday)]
    [InlineData(DayOfWeek.Wednesday, DayOfWeekSet.Wednesday)]
    [InlineData(DayOfWeek.Thursday, DayOfWeekSet.Thursday)]
    [InlineData(DayOfWeek.Friday, DayOfWeekSet.Friday)]
    [InlineData(DayOfWeek.Saturday, DayOfWeekSet.Saturday)]
    public void FromDayOfWeek_maps_each_day(DayOfWeek day, DayOfWeekSet expected)
    {
        Assert.Equal(expected, DayOfWeekSetExtensions.FromDayOfWeek(day));
    }
}
