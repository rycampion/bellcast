# Changelog

All notable changes to BellCast are recorded here. Format loosely follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/); project uses [Semantic Versioning](https://semver.org/) once it reaches `v0.1.0`.

## [Unreleased]

### Added
- Initial repository scaffolding: `README`, `LICENSE` (MIT), `.gitignore` (standard .NET template), `.editorconfig`, `.vscode/settings.json`.
- Documentation stubs: `ROADMAP.md`, `ARCHITECTURE.md`, `DECISIONS.md`, `SETUP.md`, `CHANGELOG.md`.
- ADRs 0001–0004: .NET 10 target, WPF + WPF-UI, VS Code-only IDE, SQLite + Dapper persistence.
- `global.json` pinning the .NET SDK to 10.0.202 (rollForward: latestFeature).
- `BellCast.slnx` solution (.NET 10 XML format) containing four empty projects:
  - `src/BellCast.App` — WPF app targeting `net10.0-windows`
  - `src/BellCast.Core` — class library targeting `net10.0`
  - `src/BellCast.Infrastructure` — class library targeting `net10.0`, references Core
  - `tests/BellCast.Tests` — xUnit project targeting `net10.0`, references Core + Infrastructure
- Phase 1 Chunk 1 verification: `dotnet build` green (0 warnings, 0 errors), `dotnet test` passes (1 default sample test).
- NuGet dependencies on `BellCast.App`: `WPF-UI 4.2.0`, `CommunityToolkit.Mvvm 8.4.2`, `Microsoft.Extensions.Hosting 10.0.6`, `Serilog 4.3.1`, `Serilog.Extensions.Hosting 10.0.0`, `Serilog.Sinks.File 7.0.0`.
- `App.xaml` loads WPF-UI's `ThemesDictionary` (Dark) and `ControlsDictionary`.
- `App.xaml.cs` bootstraps a `Microsoft.Extensions.Hosting` `IHost` with:
  - `.UseSerilog()` writing to `%AppData%\BellCast\logs\bellcast-YYYYMMDD.log` (daily rolling, 30-day retention).
  - `ServiceCollection` registering `MainWindow` as a singleton.
  - `Application.OnStartup` starts the host and resolves + shows `MainWindow`; `OnExit` stops the host and flushes Serilog.
- `MainWindow` is now a `ui:FluentWindow` with Mica backdrop, rounded corners, custom `ui:TitleBar`, and a `ui:NavigationView` with five pages.
- Five placeholder pages under `src/BellCast.App/Views/`: `DashboardPage`, `SchedulesPage`, `SoundLibraryPage`, `HolidaysPage`, `SettingsPage`. Each uses `ui:TextBlock` typography (TitleLarge + Body Secondary) and shows a short description of its future purpose.
- `Settings` lives in the NavigationView footer; other four in the main menu.
- Phase 1 Chunk 2 verification: `dotnet build` green (0/0), app launches, log captures `BellCast starting up`, process stable with Mica-themed window visible.
