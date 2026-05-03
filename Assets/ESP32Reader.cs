using System.IO.Ports;
using UnityEngine;

public class ESP32Reader : MonoBehaviour
{
    SerialPort sp = new SerialPort("/dev/cu.usbserial-5B151593161", 115200); 

    public float ldrValue;
    public float temperature;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 20;
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                string data = sp.ReadLine();
                Debug.Log(data); // optional debug

                string[] values = data.Split(',');

                if (values.Length == 2)
                {
                    ldrValue = float.Parse(values[0]);
                    temperature = float.Parse(values[1]);
                }
            }
            catch { }
        }
    }
}