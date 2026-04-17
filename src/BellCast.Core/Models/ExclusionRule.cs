using System.Text.Json.Serialization;

namespace BellCast.Core.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(SpecificDateRule), "specificDate")]
[JsonDerivedType(typeof(DateRangeRule), "dateRange")]
[JsonDerivedType(typeof(WeekdayRule), "weekday")]
[JsonDerivedType(typeof(TimeWindowRule), "timeWindow")]
public abstract record ExclusionRule;

public sealed record SpecificDateRule(DateOnly Date) : ExclusionRule;

public sealed record DateRangeRule(DateOnly Start, DateOnly End) : ExclusionRule;

public sealed record WeekdayRule(DayOfWeek Day) : ExclusionRule;

// A window within a calendar day. Start < End means same-day; Start > End wraps past midnight.
public sealed record TimeWindowRule(TimeOnly Start, TimeOnly End) : ExclusionRule;
