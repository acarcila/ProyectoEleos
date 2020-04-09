using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private BeetleController beetleController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != playerTag) 
        {
            beetleController.flip();
        }
    }
}
