using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultArrow : MonoBehaviour
{
    public Transform body;
    public GameObject mouseTracker;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public float maxTurnSpeed = 90;
    public float smoothTime = 0.3f;
    float angle;
    float currentVelocity;
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        transform.position = mouseWorldPos;
        Debug.Log(mouseWorldPos);
    }
}
