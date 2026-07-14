using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform cam;

    void Start() => cam = Camera.main.transform;

    void LateUpdate()
    {
        transform.LookAt(
            transform.position + cam.rotation * Vector3.forward,
            cam.rotation * Vector3.up
        );
    }
}