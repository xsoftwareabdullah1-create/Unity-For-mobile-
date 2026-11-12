# Roadmap

Every milestone needs a testable artifact. Source code alone does not mean a feature is complete.

## Phase 1 — Android editor foundation
- [x] Product goals and platform constraints.
- [x] Editor/runtime/platform architecture.
- [x] Initial .NET Android application project.
- [x] Hierarchy, Inspector and wireframe Scene Preview shell.
- [x] Local scene JSON persistence.
- [x] Project, C# source and Console docks.
- [x] GitHub Actions ARM64 APK workflow added.
- [ ] CI build passes and APK artifact is verified.
- [ ] Install and launch on a physical ARM64 phone.

**Exit gate:** successful CI build, downloadable APK and physical-device launch.

## Phase 2 — Real editor interaction
- [ ] Responsive panel drawers and tablet layout.
- [ ] Create/open/rename projects and scenes.
- [ ] Parent/child hierarchy and drag reorder.
- [ ] Complete transform editor (position, rotation, scale).
- [ ] Component add/remove and editable properties.
- [ ] Autosave, undo/redo and recovery.

## Phase 3 — Rendering
- [ ] OpenGL ES 3.x surface and render loop.
- [ ] Real 3D cube and 2D sprite rendering.
- [ ] Perspective/orthographic cameras and depth.
- [ ] Orbit, pan, pinch zoom and raycast selection.
- [ ] Move/Rotate/Scale gizmos.
- [ ] Mesh, texture, material and light import.

**Exit gate:** touch-edit a scene and see actual GPU-rendered output.

## Phase 4 — Game runtime
- [ ] Entity/component/transform runtime.
- [ ] Parent-child world transforms.
- [ ] Awake, Start, Update, FixedUpdate and OnDestroy lifecycle.
- [ ] Real Play/Pause/Step/Stop simulation.
- [ ] Play-mode scene clone and restore.
- [ ] Prefabs and scene serialization.

## Phase 5 — C# and C++
- [ ] Choose and test a C# scripting strategy on ARM64 Android.
- [ ] Script editor syntax highlighting and diagnostics.
- [ ] Script-to-component workflow and API documentation.
- [ ] Android NDK build for arm64-v8a.
- [ ] Versioned JNI/C ABI and sample native module.
- [ ] Permission prompts and safe native build isolation.

C# source editing is not script execution; C++ source storage is not native compilation. These remain separate acceptance tests.

## Phase 6 — Game systems
- [ ] 2D physics and collision.
- [ ] 3D physics.
- [ ] Audio sources, listener and mixer.
- [ ] Animation and input mapping.
- [ ] Visual scripting.
- [ ] Asset importer, materials, prefabs and packages.

## Phase 7 — Android game export
- [ ] Build settings and application metadata.
- [ ] Asset dependency collection.
- [ ] ABI and Android API validation.
- [ ] Reproducible APK packaging and signing.
- [ ] Install exported game on a second device.

## Device test matrix
- ARM64 Android phone with limited memory.
- Mid-range ARM64 phone.
- Android tablet or large-screen emulator.
- Pause/resume, rotation, low storage and GPU surface recreation.
