using System.IO.Ports;
using UnityEngine;
using System.IO.Ports;

public class LightController : MonoBehaviour
{
    public Light roomLight;

    SerialPort serial = new SerialPort("/dev/tty.usbserial-110", 115200);

    float sensorValue = 0;

    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 50;
    }

    void Update()
    {
        if (serial.IsOpen)
        {
            try
            {
                string data = serial.ReadLine();
                sensorValue = float.Parse(data);
            }
            catch { }
        }

        float intensity = Mathf.Lerp(0f, 20f, sensorValue / 4095f);
        roomLight.intensity = intensity;
    }
}