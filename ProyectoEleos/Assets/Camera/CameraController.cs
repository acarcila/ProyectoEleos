using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; //position of the player
    [Range(0, 1f)] public float smoothSpeed; //velocity of the camera
    public Vector3 offSet;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
