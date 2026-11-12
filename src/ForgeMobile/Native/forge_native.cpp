#include <jni.h>
#include <cstdint>

extern "C" JNIEXPORT jint JNICALL
Java_com_ultraforge_forgemobile_NativeBridge_nativeEngineVersion(JNIEnv*, jclass) {
    return 2;
}

extern "C" JNIEXPORT jfloat JNICALL
Java_com_ultraforge_forgemobile_NativeBridge_nativeIntegrateVelocity(JNIEnv*, jclass, jfloat velocity, jfloat acceleration, jfloat delta) {
    if (delta < 0.0f || delta > 0.25f) return velocity;
    return velocity + acceleration * delta;
}
