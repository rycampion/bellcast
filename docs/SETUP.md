# Developer Setup

Verified-working environment as of 2026-04-17.

## Prerequisites

| Tool | Minimum | Installed |
|---|---|---|
| Windows | 11 | ✅ |
| VS Code | 1.110+ | ✅ 1.111.0 |
| PowerShell | 7.x | ✅ 7.5.4 |
| Windows Terminal | latest | ✅ 1.24 |
| .NET SDK | 10.0.200+ | ✅ 10.0.202 |
| Git | 2.40+ | ✅ 2.53 |
| GitHub CLI (`gh`) | 2.80+ | ✅ 2.90.0 |

## VS Code extensions

Installed via `code --install-extension <id>`:

- `ms-dotnettools.csdevkit` — C# Dev Kit (includes XAML language support)
- `ms-dotnettools.csharp` — C# base (pulled in by Dev Kit)
- `ms-dotnettools.vscode-dotnet-runtime` — .NET install / runtime management
- `eamodio.gitlens` — inline blame, history
- `github.vscode-pull-request-github` — review PRs inside VS Code
- `editorconfig.editorconfig` — honors `.editorconfig`

## One-time configuration

### Git identity

```powershell
git config --global user.name  "rycampion"
git config --global user.email "rogercampion@agdnl.ca"
```

### GitHub CLI auth

```powershell
gh auth login
# GitHub.com → HTTPS → authenticate Git with credentials → web browser
```

## Clone and build (will work after Phase 1 lands)

```powershell
git clone https://github.com/rycampion/bellcast.git
cd bellcast
dotnet restore
dotnet build
dotnet run --project src/BellCast.App
```

## Troubleshooting

- If `gh` is not found after install, open a fresh terminal so the PATH update takes effect.
- If `dotnet` resolves to an older SDK, confirm `C:\Program Files\dotnet\` is ahead of any user-local install on your PATH.
