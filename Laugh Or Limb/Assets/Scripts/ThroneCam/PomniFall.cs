using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomniFall : MonoBehaviour
{
    private void OnEnable()
    {
        OpenDoor.Fall += Fall;
    }

    private void OnDisable()
    {
        OpenDoor.Fall -= Fall;
    }

    private void Fall()
    {
        var rb = GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D rigidbody in rb)
        {
            rigidbody.simulated = true;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
