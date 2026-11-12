# Roadmap

Each phase must produce a testable artifact. A phase is not complete merely because source code has been generated.

## Phase 1 — Foundation
- [x] Record product goals and platform constraints.
- [x] Define editor/runtime/platform boundaries.
- [x] Define C# and C++ support strategy.
- [ ] Select and pin Android-compatible dependency versions.
- [ ] Add the first compilable Android host project.
- [ ] Build and install a debug APK on an ARM64 Android device.

**Exit gate:** clean CI build plus successful installation and launch on a physical Android device.

## Phase 2 — Editor shell
- [ ] Dark editor theme and responsive landscape layout.
- [ ] Hierarchy, Scene/Game tabs, Inspector, Project and Console panels.
- [ ] Play/Pause/Step toolbar with real state transitions.
- [ ] Touch-friendly panel drawers and splitters.
- [ ] Project create/open/save.

**Exit gate:** create a project, add objects, save, close and reopen without losing the scene.

## Phase 3 — Scene editing and rendering
- [ ] Android GPU surface and render loop.
- [ ] 2D sprite and 3D cube.
- [ ] Orbit, pan and pinch camera controls.
- [ ] Selection and raycasting.
- [ ] Move/Rotate/Scale gizmos.
- [ ] Grid, camera and lighting basics.

**Exit gate:** user can create and transform scene objects with touch input and see actual rendered output.

## Phase 4 — Runtime and components
- [ ] Entity/component/transform model.
- [ ] Parent-child hierarchy and world transforms.
- [ ] Awake/Start/Update/FixedUpdate lifecycle.
- [ ] Play-mode scene clone and restore.
- [ ] Prefabs and scene serialization.

**Exit gate:** a sample scene plays, pauses, stops and restores edit-time state.

## Phase 5 — Scripting
- [ ] Device-tested C# script execution strategy.
- [ ] Code editor with syntax highlighting and diagnostics.
- [ ] Component reflection/metadata inspector.
- [ ] C++ NDK module sample and ABI bridge.
- [ ] Explicit permissions and safe build workflow for native code.

**Exit gate:** documented sample C# behavior and sample C++ native module run on supported ARM64 hardware.

## Phase 6 — Game systems
- [ ] 2D physics and collision.
- [ ] 3D physics integration.
- [ ] Audio sources, listener and mixer.
- [ ] Materials, textures and lighting.
- [ ] Animation and input mapping.
- [ ] Visual scripting.

**Exit gate:** playable 2D and 3D sample projects with repeatable tests.

## Phase 7 — Android export
- [ ] Build settings and application metadata.
- [ ] Asset dependency collection.
- [ ] ABI and minimum Android API validation.
- [ ] APK packaging and signing configuration.
- [ ] Install/run exported APK on a second device.

**Exit gate:** exported APK launches independently and runs the created game.

## Device test matrix

At minimum test:
- ARM64 Android phone with limited memory.
- Mid-range ARM64 phone.
- Android tablet or large-screen emulator.
- Pause/resume, rotation, low-storage and GPU-surface recreation.
