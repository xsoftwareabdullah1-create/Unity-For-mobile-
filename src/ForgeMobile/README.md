# Forge Mobile — Android Editor Prototype

This is the first Android application milestone for the independent Unity-inspired mobile game editor.

## Included
- Landscape-first dark editor layout.
- Selectable Hierarchy and editable Inspector.
- Add Cube / Add Empty, duplicate and delete.
- Local JSON scene persistence.
- Play / Stop snapshot restore, Pause and Step editor controls.
- Project, C# Scripts and Console docks.
- C# source editor and file saving.
- Starter C++ NDK module source and ABI notes.
- GitHub Actions ARM64 APK build.

## Prototype limits
The Scene View currently draws a lightweight wireframe preview using Android Canvas; it is not yet a GPU-backed 3D renderer. Play Mode manages editor state and snapshot restoration; there is not yet a game runtime loop. Saving C# writes a source file but does not compile or execute it. C++ source is stored but is not compiled on-device.

The next phases add OpenGL ES rendering, a runtime component lifecycle, a verified C# scripting strategy and an NDK build pipeline.

## Build
Install .NET 9 SDK, Java 17 and the .NET Android workload, then run:

    dotnet workload install android
    dotnet restore ForgeMobile.csproj
    dotnet publish ForgeMobile.csproj -c Release -f net9.0-android -p:AndroidPackageFormat=apk -p:AndroidSupportedAbis=arm64-v8a

The GitHub Actions workflow builds on pushes to main and manual dispatch. A successful ARM64 APK build has been verified in run 10; the ForgeMobile-Android-APK artifact was uploaded (about 4.0 MiB). Physical-device installation is not yet verified. Download the artifact from the Actions run page.

## Project storage
The app creates ForgeProjects/MyFirstGame inside private app storage:
- Scenes/MainScene.json
- Scripts/SpinBehaviour.cs
- Assets/
- Native/forge_sample.cpp
- Native/README.md
