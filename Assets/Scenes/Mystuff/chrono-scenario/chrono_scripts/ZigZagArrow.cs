using UnityEngine;

public class ZigZagArrow : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 direction = Vector3.up; // Choose direction in Inspector
    public float moveDistance = 0.5f;
    public float moveSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // Normalize so speed stays consistent
        direction = direction.normalized;
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = startPos + direction * movement;
    }
}