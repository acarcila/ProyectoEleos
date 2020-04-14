using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private BeetleController beetleController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer))) 
        {
            beetleController.flip();
        }
    }
}
