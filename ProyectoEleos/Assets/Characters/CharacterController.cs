using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    void Start()
    {
        toStart();
    }

    void Update()
    {
        toUpdate();
    }

    void FixedUpdate()
    {
        toFixedUpdate();
    }

    public abstract void takeDamage(int damage);
    public abstract void toStart();
    public abstract void toUpdate();
    public abstract void toFixedUpdate();
}
