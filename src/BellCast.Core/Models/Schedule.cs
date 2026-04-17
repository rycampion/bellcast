using BellCast.Core.Recurrence;

namespace BellCast.Core.Models;

public sealed record Schedule(
    Guid Id,
    string Name,
    bool Enabled,
    Guid SoundFileId,
    string? OutputDeviceId,
    RecurrenceSpec Recurrence,
    IReadOnlyList<Guid> ExclusionSetIds,
    int FadeInMs,
    int FadeOutMs,
    bool Loop,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
