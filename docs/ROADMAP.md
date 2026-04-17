# Roadmap

Phase-by-phase delivery plan. Each phase lands on a feature branch, is reviewed via pull request, merged to `main`, and summarized in [CHANGELOG.md](CHANGELOG.md).

## Status legend

- ⬜ Not started
- 🟡 In progress
- ✅ Done

---

## Phase 0 — Environment verification ✅

Verify `.NET 10 SDK`, `git`, `gh`, VS Code, PowerShell 7, Windows Terminal, and required extensions are installed and configured.

## Phase 0.5 — Source control & docs 🟡

- Local Git repo with standard `.gitignore`
- `README`, `LICENSE` (MIT), `docs/` stubs
- Public GitHub repo `rycampion/bellcast` with initial commit pushed

## Phase 1 — Project skeleton ⬜

- Solution (`BellCast.slnx` — .NET 10 XML format) with `BellCast.App` (WPF), `BellCast.Core`, `BellCast.Infrastructure`, `BellCast.Tests`
- `global.json` pinning .NET 10
- WPF-UI theming + shell window with empty nav to five pages
- Serilog rolling file logging
- Build & run verification

## Phase 2 — Domain & persistence ⬜

- Models: `Schedule`, `RecurrenceSpec` variants, `SoundFile`, `ExclusionSet`, `AppSettings`
- SQLite + Dapper, versioned migrations
- Round-trip tests

## Phase 3 — Audio engine ⬜

- `IAudioEngine` in Core; NAudio implementation using WASAPI per-device
- Fade envelope, looping
- Small in-app test harness

## Phase 4 — Scheduling engine ⬜

- Quartz.NET hosted service
- `RecurrenceSpec → ITrigger` translator, heavy unit coverage
- Exclusion evaluation in-job; `TriggerEvent` logging

## Phase 5 — UI views ⬜

- Dashboard, Schedules, Sound Library, Holidays/Exclusions, Settings
- Wizard + advanced edit modes; test-play everywhere
- Accessibility pass

## Phase 6 — Tray, autostart, NTP, import/export ⬜

- `H.NotifyIcon.Wpf` tray with single-instance enforcement
- `HKCU\...\Run` autostart toggle
- SNTP client; import/export schedules+settings JSON

## Phase 7 — Polish ⬜

- Empty states, toasts, first-run experience, animations
- Performance snapshot

## Phase 8 — Installer, CI, user docs ⬜

- Inno Setup installer
- GitHub Actions: build + test on push/PR
- User guide with screenshots
- Tag `v0.1.0`

---

## Deferred / Nice-to-have (not in MVP)

- Multi-zone audio routing
- LAN web dashboard / remote trigger
- In-app announcement recording
- Volume scheduling
- Admin password / user roles
