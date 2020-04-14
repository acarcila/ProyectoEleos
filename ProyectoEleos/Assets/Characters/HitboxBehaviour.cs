using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehaviour : MonoBehaviour
{
    [SerializeField] private string otherTag;
    [SerializeField] private StatsController statsController;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == otherTag)
        {
            Debug.Log(other.name + " stay");
            //hacer daño
            other.gameObject.GetComponent<CharacterController>().takeDamage(statsController.getDamage());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == otherTag)
        {
            Debug.Log(other.name + " enter");
            //hacer daño
            other.gameObject.GetComponent<CharacterController>().takeDamage(statsController.getDamage());
        }
    }
}
