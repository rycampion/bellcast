namespace BellCast.Core.Models;

public sealed record SoundFile(
    Guid Id,
    string DisplayName,
    string RelativePath,
    DateTimeOffset ImportedAt,
    int DurationMs,
    string Format);
