# Decisions Log

Architectural decisions recorded ADR-style. Each entry: short title, date, context, decision, consequences.

---

## ADR-0001: Target .NET 10 over .NET 8 LTS

**Date:** 2026-04-17
**Status:** Accepted

**Context.** The project must run on modern Windows 11. Both .NET 8 LTS (supported through Nov 2026) and .NET 10 are available on the dev machine (SDKs 10.0.201 and 10.0.202 installed, with the WindowsDesktop runtime). The original prompt recommended .NET 8 LTS for broad library compatibility and long support; .NET 10 is newer with more language/runtime features.

**Decision.** Target **.NET 10** via `global.json`.

**Consequences.**
- Latest C# language features and runtime improvements available.
- Some NuGet packages may lag slightly; we'll pin versions known to support .NET 10 (WPF-UI, NAudio, Quartz.NET, CommunityToolkit.Mvvm, Serilog are all current).
- End users will need the .NET 10 Desktop runtime installed; the Phase 8 installer will handle that.
- If a critical library blocks us, we can downgrade to .NET 8 LTS with low friction.

---

## ADR-0002: WPF + WPF-UI (lepoco) instead of WinUI 3

**Date:** 2026-04-17
**Status:** Accepted

**Context.** We need a modern Fluent-design Windows desktop shell that works smoothly with VS Code + C# Dev Kit. WinUI 3 offers truly native Fluent controls but essentially requires MSIX packaging and is Visual Studio 2022-centric. WPF is mature, VS Code-friendly, and the WPF-UI library gives a close-to-WinUI visual experience.

**Decision.** Build the app on **WPF** (`net10.0-windows`, `UseWPF=true`) with the **WPF-UI** NuGet package for Fluent styling (Mica, acrylic, modern controls).

**Consequences.**
- Deployment stays simple — a single `.exe` and `.dll`s, installable via Inno Setup without MSIX complexity.
- VS Code + C# Dev Kit workflow is fully supported.
- Slightly less cutting-edge visual polish than native WinUI 3, acceptable for MVP.
- If WPF-UI proves insufficient, ModernWpfUI is a drop-in alternative with a similar aesthetic.

---

## ADR-0003: Single IDE — VS Code only

**Date:** 2026-04-17
**Status:** Accepted

**Context.** Roger is not a full-time developer and wants to avoid juggling multiple IDEs. Visual Studio 2022 would work but adds complexity; VS Code with the C# Dev Kit handles .NET development end-to-end and is where Claude Code lives.

**Decision.** Use **VS Code exclusively**. Visual Studio 2022 is not required and should not be used for this project unless a blocker emerges.

**Consequences.**
- Clean workflow: edit, build, and debug in one window.
- Some advanced WPF designer features (visual XAML designer) are not available; XAML is written directly.
- If a VS 2022-only blocker appears later, we document it here and revisit.

---

## ADR-0004: SQLite + Dapper for persistence

**Date:** 2026-04-17
**Status:** Accepted

**Context.** The app is local-first and single-user; no multi-tenant concerns. We need durable storage for schedules, sound-file metadata, exclusion sets, app settings, and trigger events.

**Decision.** Use **SQLite** via `Microsoft.Data.Sqlite` with **Dapper** for lightweight mapping. Schema migrations via a small custom runner (one SQL file per version), not EF Core.

**Consequences.**
- Minimal dependencies, fast startup, easy backup (copy one file).
- No heavy ORM overhead; schema changes are explicit and reviewable.
- If domain complexity grows, we can migrate to EF Core later with modest effort.
