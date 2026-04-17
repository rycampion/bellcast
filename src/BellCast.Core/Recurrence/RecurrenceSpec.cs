using System.Text.Json.Serialization;

namespace BellCast.Core.Recurrence;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(OneTimeRecurrence), "oneTime")]
[JsonDerivedType(typeof(HourlyRecurrence), "hourly")]
[JsonDerivedType(typeof(DailyRecurrence), "daily")]
[JsonDerivedType(typeof(WeeklyRecurrence), "weekly")]
[JsonDerivedType(typeof(DayOfMonthRecurrence), "dayOfMonth")]
[JsonDerivedType(typeof(NthWeekdayOfMonthRecurrence), "nthWeekdayOfMonth")]
[JsonDerivedType(typeof(AnnuallyRecurrence), "annually")]
public abstract record RecurrenceSpec;

public sealed record OneTimeRecurrence(DateTimeOffset Moment) : RecurrenceSpec;

public sealed record HourlyRecurrence(int Minute, int Second) : RecurrenceSpec;

public sealed record DailyRecurrence(TimeOnly Time) : RecurrenceSpec;

public sealed record WeeklyRecurrence(DayOfWeekSet Days, TimeOnly Time) : RecurrenceSpec;

// Day is 1-31. 31 is interpreted as "last day of month" when the month is shorter.
public sealed record DayOfMonthRecurrence(int Day, TimeOnly Time) : RecurrenceSpec;

// N is 1-5. 5 is interpreted as "last <Weekday> of the month".
public sealed record NthWeekdayOfMonthRecurrence(int N, DayOfWeek Weekday, TimeOnly Time) : RecurrenceSpec;

public sealed record AnnuallyRecurrence(int Month, int Day, TimeOnly Time) : RecurrenceSpec;
