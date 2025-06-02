using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move left and right
    public float speed = 2f;        // Movement speed

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move left and right using a sine wave
        float offset = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}
