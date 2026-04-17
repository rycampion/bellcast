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
