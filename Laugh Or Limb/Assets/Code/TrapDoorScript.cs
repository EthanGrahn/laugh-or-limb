using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorScript : MonoBehaviour
{
    public Rigidbody2D leftDoor, rightDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leftDoor.bodyType = RigidbodyType2D.Dynamic;
            rightDoor.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
