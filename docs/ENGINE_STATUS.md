# Engine implementation status

This repository now contains a modular engine foundation: scene graph and transforms, scene serialization/validation, primitive mesh data, render command queues and camera math, simple rigid-body integration, a restricted safe scripting VM, asset indexing, editor selection/undo/inspector metadata models, project/build profiles, touch input abstractions, audio/animation data models and a sample C++ JNI source.

## Explicit limitations

- The Android viewport is still a Canvas preview. The rendering abstractions are not yet connected to a GPU render loop.
- The safe script VM executes a deliberately small command language (log, set, move); it is not a full C# compiler or arbitrary C# runtime.
- The C++ sample and JNI contract are source only; NDK build/package integration is pending.
- Physics is a simple integrator foundation, not a complete collision solver.
- Audio/animation are data and timing foundations, not full device playback/animation pipelines.
- Standalone game APK export remains a separate milestone.

Features are marked complete only after a device/CI test proves them.
