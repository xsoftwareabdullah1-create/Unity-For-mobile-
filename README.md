# Unity-Style Mobile Game Engine

An independent, mobile-first game creation environment inspired by professional game-editor workflows. The target is to let creators build and test 2D/3D Android games from a touchscreen device.

This is not Unity and contains no Unity source code or proprietary assets.

## Current app: Forge Mobile

The first Android editor prototype lives in src/ForgeMobile.

- Dark landscape editor shell with Hierarchy, Scene Preview and Inspector.
- Add Cube / Empty, duplicate, delete and edit object transforms.
- Local JSON scene saving.
- Play/Stop scene snapshot, Pause and Step editor controls.
- Project, C# Scripts and Console docks.
- C# source editor that saves script files.
- Starter C++ NDK module source and native ABI notes.
- GitHub Actions ARM64 APK build.

**Prototype limits:** the viewport is currently a Canvas wireframe preview, not a GPU 3D renderer. Play Mode is an editor-state prototype, not a running game runtime. C# and C++ files can be edited/stored, but are not compiled or executed yet.

## Language plan

- **C#** — primary engine and gameplay language; Android-compatible scripting execution is still to be selected and device-tested.
- **C++** — native modules built with Android NDK and connected through a versioned JNI/C ABI.
- **GLSL** — rendering shaders.
- **Visual scripting** — planned node-based authoring.

Arbitrary C# runtime compilation and arbitrary native library loading are not assumed to work on Android. Those capabilities require a verified, secure implementation.

## Repository structure

- src/ForgeMobile/ — Android application and editor prototype.
- docs/ARCHITECTURE.md — technical boundaries and design.
- docs/ROADMAP.md — milestones and acceptance gates.
- .github/workflows/android-editor.yml — CI APK build.

## Build

GitHub Actions builds an ARM64 APK on pushes affecting the Android project, and on manual workflow dispatch. Open the Actions tab and download the ForgeMobile-Android-APK artifact after a successful run.

Local build prerequisites: .NET 9 SDK, Java 17 and the .NET Android workload.

    dotnet workload install android
    dotnet restore src/ForgeMobile/ForgeMobile.csproj
    dotnet publish src/ForgeMobile/ForgeMobile.csproj -c Release -f net9.0-android -p:AndroidPackageFormat=apk -p:AndroidSupportedAbis=arm64-v8a

## Roadmap

1. Stabilize the Android editor and CI build.
2. Add a real OpenGL ES scene renderer and touch camera controls.
3. Implement entity/component runtime and actual Play Mode execution.
4. Validate C# scripting on ARM64 Android.
5. Add the Android NDK C++ build and native module bridge.
6. Add physics, audio, animation, materials, asset import and visual scripting.
7. Export standalone Android game APKs.

See Architecture and Roadmap documents in docs/.
