# Build and model export matrix

| Output | Status | Download / notes |
|---|---|---|
| Android APK | Available from CI | Latest successful Android workflow artifact |
| Android AAB | Available from CI | Latest successful Android workflow artifact |
| OBJ mesh | Exported by Model Maker | Saved under app-private ClearGameEngine/Exports |
| ASCII STL mesh | Exported by Model Maker | Saved under app-private ClearGameEngine/Exports |
| GLB / glTF | Planned | Not implemented |
| FBX | Planned | Not implemented |
| PLY | Planned | Not implemented |
| Windows EXE | Not available | Needs a Windows editor/runtime target and packaging |
| macOS DMG | Not available | Needs a macOS editor/runtime target and packaging |
| Linux packages | Not available | Needs a Linux editor/runtime target |
| WebAssembly | Not available | Needs a browser runtime and web asset pipeline |

A file extension is not automatically a build target. Every export needs a real serializer or runtime, platform toolchain, packaging step and test. Placeholder files should never be shown as downloads.
