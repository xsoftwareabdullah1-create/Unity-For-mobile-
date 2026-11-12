# Unity-Style Mobile Game Engine

A mobile-first game creation environment inspired by the workflow of Unity Editor. The goal is to let creators build, test, and package 2D and 3D Android games directly from a touchscreen device.

> This is an independent engine project. It will use an original implementation and original assets; it is not Unity, does not include Unity source code, and will not copy Unity's proprietary branding or assets.

## Target experience

- Dark, dockable editor layout adapted for phone and tablet screens.
- Scene and Game views, Hierarchy, Inspector, Project/Assets, Console and Play/Pause/Step controls.
- Touch-first object selection, transform gizmos, camera orbit/pan/zoom, drag-and-drop and searchable component menus.
- 2D and 3D scenes, materials, lights, cameras, audio, animation and physics.
- C# gameplay scripting and native C++ extension modules.
- Android APK export, with desktop/iOS considered only after the Android pipeline is stable.

## Language support

- **C#**: primary gameplay and editor/engine code.
- **C++**: native engine modules and performance-sensitive extensions through the Android NDK/JNI boundary.
- **GLSL**: shaders.
- **Visual scripting**: planned node graph for creators who prefer not to type code.

Important Android runtime constraint: arbitrary Roslyn compilation and dynamic assembly loading cannot be assumed to work on every Android/AOT configuration. The implementation must validate a supported C# scripting strategy on-device (precompiled script assemblies or an explicitly supported interpreter/compiler path) before advertising instant compile-and-run. C++ compilation will require a compatible NDK toolchain and must be treated separately from in-app script execution.

## Development status

The repository was empty at project start. This commit establishes the architecture and phased implementation plan; it is not yet a functioning game engine and does not produce an APK.

1. **Foundation** — architecture, editor shell, project format and Android build pipeline.
2. **Editor core** — Hierarchy, Inspector, asset browser, Console and project persistence.
3. **Rendering** — 2D/3D viewport, camera controls, grid and selection.
4. **Scene/runtime** — entities, components, lifecycle, play-mode isolation.
5. **Scripting** — verified C# workflow and C++ native module interface.
6. **Creation tools** — physics, audio, animation, materials, prefabs and visual scripting.
7. **Packaging** — reproducible Android APK export and sample projects.

## Current documentation

- [Architecture and technical decisions](docs/ARCHITECTURE.md)
- [Roadmap and acceptance criteria](docs/ROADMAP.md)

## Build status

No application source or APK is included yet. Build automation will be added with the first compilable Android application rather than creating a misleading workflow that claims to build a nonexistent project.

## License

A license will be selected before distributing engine binaries or bundled third-party dependencies. Third-party libraries retain their own licenses.
