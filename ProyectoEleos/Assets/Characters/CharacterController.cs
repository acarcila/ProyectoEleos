using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        toStart();
    }

    // Update is called once per frame
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
