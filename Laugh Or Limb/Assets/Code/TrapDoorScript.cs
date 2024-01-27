using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorScript : MonoBehaviour
{
    public GameObject leftSide, rightSide;
    float finalRot;
    // Start is called before the first frame update
    void Start()
    {
        leftSide.GetComponent<Rigidbody2D>().isKinematic = false;
        rightSide.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leftSide.GetComponent<Rigidbody2D>().isKinematic = true;
            rightSide.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
