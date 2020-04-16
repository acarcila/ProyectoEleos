using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private float parallaxSpeedX;
    [SerializeField] private float parallaxSpeedY;
    [SerializeField] private Transform mainCamera;

    private Vector2 cameraStartPosition;
    private Vector2 startPosition;

    void Start()
    {
        cameraStartPosition = mainCamera.transform.position;
        startPosition = transform.position;
    }

    void Update()
    {
        // transform.localPosition = new Vector2(startPosition.x - (mainCamera.transform.position.x * parallaxSpeedX), startPosition.y - (mainCamera.transform.position.y * parallaxSpeedY));
        Vector2 cameraCurrentPosition = mainCamera.transform.position;
        Vector2 delta = cameraStartPosition - cameraCurrentPosition;

        transform.localPosition = new Vector2(startPosition.x - (delta.x * parallaxSpeedX), startPosition.y - (delta.y * parallaxSpeedY));
    }
}
