namespace BellCast.Core.Recurrence;

[Flags]
public enum DayOfWeekSet
{
    None = 0,
    Sunday = 1 << 0,
    Monday = 1 << 1,
    Tuesday = 1 << 2,
    Wednesday = 1 << 3,
    Thursday = 1 << 4,
    Friday = 1 << 5,
    Saturday = 1 << 6,

    Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    Weekend = Saturday | Sunday,
    EveryDay = Weekdays | Weekend,
}

public static class DayOfWeekSetExtensions
{
    public static bool Contains(this DayOfWeekSet set, DayOfWeek day) =>
        (set & FromDayOfWeek(day)) != DayOfWeekSet.None;

    public static DayOfWeekSet FromDayOfWeek(DayOfWeek day) => day switch
    {
        DayOfWeek.Sunday => DayOfWeekSet.Sunday,
        DayOfWeek.Monday => DayOfWeekSet.Monday,
        DayOfWeek.Tuesday => DayOfWeekSet.Tuesday,
        DayOfWeek.Wednesday => DayOfWeekSet.Wednesday,
        DayOfWeek.Thursday => DayOfWeekSet.Thursday,
        DayOfWeek.Friday => DayOfWeekSet.Friday,
        DayOfWeek.Saturday => DayOfWeekSet.Saturday,
        _ => DayOfWeekSet.None,
    };
}
