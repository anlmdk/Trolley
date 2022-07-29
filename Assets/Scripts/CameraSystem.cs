using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform player;

    [SerializeField] public Vector3 offset;

    void LateUpdate()
    {
        Follow();
    }
    public void Follow()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
