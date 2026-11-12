# Native C++ module

This folder contains a small Android NDK C++17 sample and JNI contract. It is not yet wired into the Android packaging pipeline. Build with Android NDK CMake for arm64-v8a, package the resulting shared library under jniLibs/arm64-v8a, then add explicit load/error handling before calling native methods. Never load untrusted native binaries.
