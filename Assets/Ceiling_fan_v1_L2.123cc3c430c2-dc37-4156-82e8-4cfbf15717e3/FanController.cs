using UnityEngine;

public class FanController : MonoBehaviour
{
    public ESP32Reader serial;
    public float maxSpeed = 500f;

    void Update()
    {
        if (serial == null) return;

        float speed = Mathf.Lerp(0, maxSpeed, serial.temperature / 40f);
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}