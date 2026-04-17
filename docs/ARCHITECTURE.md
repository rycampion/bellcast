# Architecture

> Living document — updated as each phase lands. Contents are placeholder until Phase 1 lands the skeleton.

## High-level shape

BellCast will be a single Windows desktop process split into four logical assemblies:

```
+-----------------------+
|  BellCast.App (WPF)   |   UI, view models, DI bootstrap, tray
+----------+------------+
           |
           v
+-----------------------+
|     BellCast.Core     |   Domain models, contracts, no platform deps
+----------+------------+
           |
           v
+---------------------------+
|  BellCast.Infrastructure  |  SQLite, NAudio, Quartz.NET, NTP, Serilog
+---------------------------+

+-----------------------+
|    BellCast.Tests     |   xUnit + FluentAssertions
+-----------------------+
```

## Cross-cutting concerns

- **DI container:** `Microsoft.Extensions.DependencyInjection` via `IHost`.
- **Logging:** Serilog, rolling daily file at `%AppData%\BellCast\logs\bellcast-.log`.
- **Persistence root:** `%AppData%\BellCast\` — database, sounds, logs, settings.
- **MVVM:** CommunityToolkit.Mvvm (source generators for observable properties and relay commands).

## Details to be filled in

- Service lifetimes and registrations (Phase 1)
- Database schema + migration strategy (Phase 2)
- Audio playback pipeline, device enumeration quirks (Phase 3)
- `RecurrenceSpec → Quartz ITrigger` mapping table (Phase 4)
- View / view-model wiring (Phase 5)
- Tray + autostart integration points (Phase 6)
