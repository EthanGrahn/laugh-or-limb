using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject item;
    public GameObject body;
    public float distance = -40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera.transform.rotation = Quaternion.identity;
        item.transform.position = new Vector3(body.transform.position.x, body.transform.position.y, distance);
    }
}
