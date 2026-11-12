# Architecture

## Product goal

Create an independent, mobile-first 2D/3D game engine and editor that reproduces the useful workflow patterns of a professional desktop editor on Android phones and tablets. The visual design may be Unity-inspired (dark panels, hierarchy, inspector, scene/game tabs, transform tools), but all implementation, icons, branding and assets must be original.

## Proposed stack

| Layer | Initial choice | Responsibility |
|---|---|---|
| Android host/editor | .NET for Android with a native Android UI shell | App lifecycle, touch, file picker, permissions, project manager |
| Editor UI | Dear ImGui docking through ImGui.NET, with a mobile touch adaptation layer | Dockable editor panels and toolbars |
| Engine core | C# on .NET 10, separated from Android-specific code | Scene, entity/component model, assets, serialization, editor services |
| Graphics | Silk.NET bindings; OpenGL ES 3.x baseline, Vulkan as a later backend | 2D/3D rendering and GPU resource management |
| Native extensions | C++17/20 Android NDK libraries through JNI/P/Invoke boundary | Native physics or user extensions where justified |
| Physics | Box2D for 2D; Jolt or another compatible 3D engine after Android integration validation | Collision and simulation |
| Audio | Android audio backend with a portable mixer abstraction | Spatial and non-spatial audio |
| Project format | Versioned JSON metadata plus binary asset files | Portable project storage and migration |
| Android packaging | Gradle/.NET Android packaging and NDK toolchain | APK output |

These are candidate choices, not claims that every library has already been integrated. Each dependency must be pinned to a tested version and checked for Android ABI, licensing, and maintenance status before implementation.

## Runtime/editor separation

The editor must not own game-state logic. It edits a project and sends commands to the engine runtime.

- **Editor layer:** windows, docking, touch input, selection, inspectors, asset import UI and debugging.
- **Engine layer:** scenes, entities, components, transforms, resource handles, renderer, physics and audio.
- **Runtime layer:** executes a cloned/isolated scene in Play Mode so stopping a game can restore the edit-time scene.
- **Platform layer:** Android lifecycle, storage access, GPU surface, JNI and native library loading.
- **Build layer:** validates assets and scripts, then packages the runtime and project content into an APK.

## Editor layout

Landscape phone/tablet layout:
- Top: project title, tool modes, pivot/local toggles and Play/Pause/Step.
- Left drawer: Hierarchy.
- Center: Scene and Game tabs.
- Right drawer: Inspector.
- Bottom dock: Project/Assets and Console.
- Small screens: panels collapse into tabs/drawers; splitters and touch targets remain large enough for fingers.
- Tablets: multi-panel docking is enabled.

The scene viewport needs a dedicated render surface. UI panels must not fake the 3D viewport with a static image.

## Scene and component model

Initial core contracts:
- Entity has a stable ID, name, enabled state and component collection.
- Transform stores local position, rotation and scale; world transform is derived from the parent chain.
- Scene stores entities and parent/child relationships.
- Components expose lifecycle hooks: Awake, Start, Update, FixedUpdate and OnDestroy.
- Component lookup and entity instantiation are runtime services.
- Serialization uses stable type identifiers and schema versions, never arbitrary assembly-qualified names from untrusted project files.

## C# scripting on Android

Do not assume desktop Roslyn behavior works unchanged on Android. Android deployment may use AOT restrictions and runtime code-generation limitations. The project must prototype and test one supported model:
1. compile gameplay scripts ahead of time into assemblies included with the project/runtime, or
2. embed a scripting interpreter with a documented subset of C#-like APIs, or
3. provide an external build companion that compiles scripts and returns Android-compatible assemblies.

The chosen route must be tested on a real ARM64 Android device. The editor must show clear compile diagnostics and must never report successful compilation when scripts were not actually compiled.

## C++ support

C++ is for native modules, engine extensions and performance-sensitive systems. Android NDK builds produce ABI-specific shared libraries (initially arm64-v8a). A narrow, versioned C ABI/JNI bridge should isolate native code from managed engine internals. User-supplied C++ must not be compiled or executed without explicit project permissions and a controlled build process.

## Rendering plan

1. Establish an Android GPU surface and clear the screen.
2. Draw a 2D sprite and a 3D cube.
3. Add perspective/orthographic cameras, depth testing and a world grid.
4. Add mesh/material asset loading and directional/point lights.
5. Add shadows and PBR incrementally, gated by device capability.
6. Keep OpenGL ES as the compatibility baseline; add Vulkan only after device coverage and recovery paths are tested.

## Security and reliability

- Treat project files, imported assets and scripts as untrusted input.
- Validate archive paths to prevent zip-slip during import/export.
- Limit asset sizes and report decode failures without crashing the editor.
- Keep autosave/recovery snapshots and version project schemas.
- Never load arbitrary native libraries from an untrusted project.
- Handle Android activity pause/resume and GPU surface recreation.
- Provide memory budgets and graceful quality settings for lower-end devices.

## Performance targets

Targets must be measured on real devices; do not promise desktop-equivalent performance. Use frame-time, memory, thermal and battery profiling. Prefer configurable render quality, asset streaming and bounded caches. Optimize allocations only after profiling identifies hot paths.

## Non-goals for the first milestone

- Full parity with every Unity feature.
- iOS export before Android is stable.
- Arbitrary native C++ compilation inside the running app.
- Guaranteed dynamic C# compilation on all Android versions.
- Commercial asset store or cloud collaboration.
