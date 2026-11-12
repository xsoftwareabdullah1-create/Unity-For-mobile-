# Forge Mobile — Unity-inspired Android Game Editor

Forge Mobile is an independent, mobile-first game editor and engine foundation. It is inspired by professional Unity-style workflows, but it is not Unity and contains no Unity proprietary source or assets.

## Current editor

- Landscape editor workspace with Hierarchy, Scene and Inspector.
- Scrollable Inspector with object metadata, custom key/value metadata, transform fields, components and renderer information.
- Create, duplicate and delete scene objects.
- Edit position, rotation, scale, tag, layer, active and static flags.
- Local JSON scene persistence.
- Project, Console and C# source docks.
- Dark graphite/blue theme and touch-sized outlined controls.

## Engine modules added

More than 120 source and support files have been added under `src/ForgeMobile/Engine`:

- **Core:** clock, event bus, scheduler, service container, logging, validation.
- **Scene:** entity graph, transforms, components, cameras, lights, mesh/material descriptors, serialization and validation.
- **Rendering foundation:** primitive cube/plane mesh data, camera projection math, orbit controller, grid builder, picking ray, render queue and resource descriptors.
- **Physics foundation:** rigid-body integration, collider types and material settings.
- **Scripting:** a safe, restricted command VM with `log`, `set` and `move` instructions.
- **Assets:** asset database, extension classification, dependency graph and search index.
- **Editor:** Inspector metadata models, selection, tools, undo history, console, layout, themes and preferences.
- **Input, audio, animation and Android build-profile models.**
- **Native:** C++17 JNI sample source and CMake definition.

## Build and tests

The GitHub Actions workflow runs dependency-free engine smoke tests, then builds an ARM64 Android APK.

Local prerequisites: .NET 10 SDK, Java 17 and the .NET Android workload.

```bash
dotnet run --project src/ForgeMobile.Tests/ForgeMobile.Tests.csproj -c Release
dotnet workload install android
dotnet restore src/ForgeMobile/ForgeMobile.csproj
dotnet publish src/ForgeMobile/ForgeMobile.csproj -c Release -f net10.0-android -p:AndroidPackageFormat=apk --output artifacts/apk
```

Open the repository's **Actions** tab and download `ForgeMobile-Android-APK` after a successful run.

## Important implementation limits

This is a growing engine project, not a complete Unity replacement yet.

- The current Android Scene View still uses a Canvas preview; the GPU renderer is not wired up yet. Rendering classes added so far are engine-side data/math/command foundations.
- The script VM is a deliberately restricted safe command language. It does not compile or execute arbitrary C#.
- C++ JNI/CMake sample source is present, but NDK build and APK packaging integration are not yet complete.
- Physics currently provides basic rigid-body integration and collider data, not a full collision solver.
- Audio and animation modules are data/timing foundations, not full device playback/rendering systems.
- Standalone game APK export is not implemented yet.

See `docs/ENGINE_STATUS.md`, `docs/ROADMAP.md` and `docs/METADATA_INSPECTOR.md` for exact status and next milestones.
