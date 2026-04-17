namespace BellCast.Core.Models;

public sealed record ExclusionSet(
    Guid Id,
    string Name,
    IReadOnlyList<ExclusionRule> Rules);
