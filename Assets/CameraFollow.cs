using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(0, 5, -7);
            transform.LookAt(target);
        }
    }
}