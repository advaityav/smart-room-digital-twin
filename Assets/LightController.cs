using UnityEngine;

public class LightController : MonoBehaviour
{
    public ESP32Reader serial;
    public Light roomLight;

    float minLdr = 4095f;
    float maxLdr = 0f;

    void Update()
    {
        if (serial == null || roomLight == null) return;

        float ldr = serial.ldrValue;

        // Auto-calibration
        if (ldr < minLdr) minLdr = ldr;
        if (ldr > maxLdr) maxLdr = ldr;

        float range = maxLdr - minLdr;
        if (range < 1f) range = 1f;

        // Normalize (0 → 1)
        float normalized = (ldr - minLdr) / range;

        // Invert (dark → 1, bright → 0)
        normalized = 1f - normalized;

        // 🔥 VERY AGGRESSIVE EXPONENTIAL
        float curved = Mathf.Pow(normalized, 5f);   // try 5, 6, 7 for stronger effect

        // Allow near-zero brightness
        float targetIntensity = Mathf.Lerp(0.0f, 6f, curved);

        // Smooth transition
        roomLight.intensity = Mathf.Lerp(roomLight.intensity, targetIntensity, 6f * Time.deltaTime);
    }
}