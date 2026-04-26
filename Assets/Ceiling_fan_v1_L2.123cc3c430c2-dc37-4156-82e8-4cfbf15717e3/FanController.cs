using UnityEngine;

public class FanController : MonoBehaviour
{
    public float speed = 200f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}