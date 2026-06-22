# CellsX10

A tiny [Dead Cells Core Modding (DCCM)](https://github.com/dead-cells-core-modding/core) mod that
gives you **10× cells** on pickup.

## What it does

Every time the game awards cells, CellsX10 multiplies the amount by **10**.

## Why

The obvious way to "get more cells" is to make enemies drop more cell pickups — but that floods the
screen with a pile of pickup orbs and their collection animations every time something dies. CellsX10
instead scales the **value** of the cells you already pick up, so you get 10× the cells with the same
clean, single pickup animation and no visual spam.

## How it works

CellsX10 is a code mod. It hooks `Beheaded.addCells` (the method the game calls to grant cells) and
multiplies the granted value before passing it on:

```csharp
private static void OnAddCells(Hook_Beheaded.orig_addCells orig, Beheaded self, int val, Ref<bool> noStats)
    => orig(self, val * 10, noStats);
```

Because it touches the award value and not the number of dropped pickups, drop spawning and pickup
animations are completely unchanged.

## Requirements

* Dead Cells
* [DCCM (Dead Cells Core Modding)](https://github.com/dead-cells-core-modding/core)

Built against DCCM core version **35.9.27**.

## Installation

1. Make sure DCCM is installed.
2. Download `CellsX10.zip` from the [latest release](../../releases/latest).
3. Extract it into your game's `coremod/mods/` folder so the layout looks like this:

```text
Dead Cells/
└── coremod/
    └── mods/
        └── CellsX10/
            ├── CellsX10.dll
            └── modinfo.json
```

4. Launch the game. The log prints `[CellsX10] cells x10 on pickup enabled` once it is active.

## Building from Source

Requirements: .NET 10 SDK and the DCCM Modding Kit (pulled in via the `DeadCellsCoreModding.MDK`
NuGet package).

```bash
dotnet build -c Release
```

The packaged mod is written to `bin/Release/net10.0/output/CellsX10/`. Copy that folder into
`coremod/mods/`.

## License

Released under the [MIT License](LICENSE).
