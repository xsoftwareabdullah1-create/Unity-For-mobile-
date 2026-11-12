# Clear Game Engine

This is my Android-first game editor project. I want the workspace to feel familiar to people who have used desktop game engines: scene in the centre, hierarchy on the left, Inspector on the right, and project tools below.

It is an independent project, not Unity or Blender, and it does not contain their proprietary code or assets.

## What currently works

- Landscape editor with Hierarchy, Scene, Inspector, Project, Console and script panels.
- Create, select, duplicate and delete scene objects.
- Edit object name, tag, layer, custom metadata, active/static flags and transforms.
- Save scenes locally as JSON.
- A first Model Maker screen with cube, UV sphere and plane primitives, a touch-orbit wireframe preview, basic scale/rotation controls, and OBJ/STL export.
- Engine foundations for scene data, mesh data, camera maths, basic physics data, asset indexing and a restricted safe script VM.

## Android downloads

The GitHub Actions workflow builds both an installable **APK** and an **AAB**. Open [Actions](../../actions/workflows/android-editor.yml), select the latest successful run, and download the artifact. Workflow artifacts are retained for 14 days.

## Build locally

You need .NET 10, Java 17 and the .NET Android workload.

```sh
dotnet run --project src/ForgeMobile.Tests/ForgeMobile.Tests.csproj -c Release
dotnet workload install android
dotnet restore src/ForgeMobile/ForgeMobile.csproj
dotnet publish src/ForgeMobile/ForgeMobile.csproj -c Release -f net10.0-android -p:AndroidPackageFormat=apk --output artifacts/apk
dotnet publish src/ForgeMobile/ForgeMobile.csproj -c Release -f net10.0-android -p:AndroidPackageFormat=aab --output artifacts/aab
```

## Model and game exports

The Model Maker currently exports OBJ and ASCII STL. glTF/GLB, FBX and PLY need their own tested serializers and are not available yet.

Windows EXE, macOS DMG, Linux packages and WebAssembly game exports are not available from this Android-only project. Those need desktop/web runtime targets, platform toolchains, packaging and tests. An editor APK is not a universal game exporter.

## About app size

I am not adding filler files or fake assets to force the APK to 200–250 MB. The app should only grow when real engine code, libraries, sample projects and optional content justify it. A bloated install would waste phone storage and mobile data.

## What is still unfinished

The Scene View is currently a Canvas preview, not a production OpenGL ES renderer. The Model Maker is a primitive-mesh MVP, not Blender-level modelling software. The safe script VM is not a full C# compiler. The C++ JNI sample is not an in-app C++ build pipeline. Physics, audio and animation are foundations rather than full Unity-equivalent systems.

The plan is to keep each milestone buildable and test real features as they are added.
