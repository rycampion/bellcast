# BellCast

> A modern Windows desktop scheduler for bells, buzzers, and PA sounds.

![Status](https://img.shields.io/badge/status-pre--alpha-orange)
![License](https://img.shields.io/badge/license-MIT-blue)
![Platform](https://img.shields.io/badge/platform-Windows-0078d6)
![.NET](https://img.shields.io/badge/.NET-10-512bd4)

## What is this?

BellCast is a 2026-era replacement for legacy school/office bell-scheduling apps (think "BellWiz, rebuilt"). It schedules and plays audio files through your chosen sound output on recurring or one-off schedules, with holiday exclusions, multiple output devices, and NTP-based time sync — so bells fire on time, through the right speakers, every time.

### Planned features (MVP)

- Flexible scheduler: one-time, hourly/daily/weekly, day-of-month, nth-weekday-of-month, monthly, annually
- `.wav` and `.mp3` playback with optional loop and fade in/out
- Multiple audio output devices (send bells to the PA, keep Windows sounds on speakers)
- Holiday / exclusion sets applied per schedule
- NTP time sync with manual and scheduled modes
- System tray with optional autostart
- Import / export schedules as JSON
- Modern Fluent UI with light/dark themes
- Bundled royalty-free default sounds

See [docs/ROADMAP.md](docs/ROADMAP.md) for the phase-by-phase plan.

## Status

Pre-alpha. Currently in IDE/repo setup (Phase 0.5). No builds yet.

## Build (coming in Phase 1)

Build instructions will be added once the solution exists. Target: `.NET 10 SDK` on Windows, WPF.

## Documentation

- [docs/ROADMAP.md](docs/ROADMAP.md) — phase plan
- [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md) — system architecture (TBD)
- [docs/DECISIONS.md](docs/DECISIONS.md) — ADR-style decisions log
- [docs/SETUP.md](docs/SETUP.md) — dev environment setup
- [docs/CHANGELOG.md](docs/CHANGELOG.md) — change log

## License

[MIT](LICENSE) © 2026 Roger Campion
