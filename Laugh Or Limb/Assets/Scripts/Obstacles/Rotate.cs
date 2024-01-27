using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private int rotSpeed;
    [SerializeField]
    private bool xRotate, yRotate, zRotate;
    void Update()
    {
        if(xRotate)
            this.gameObject.transform.Rotate(new Vector3(Time.deltaTime * rotSpeed, 0, 0));
        if (yRotate)
            this.gameObject.transform.Rotate(new Vector3(0, Time.deltaTime * rotSpeed, 0));
        if (zRotate)
            this.gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }
}
