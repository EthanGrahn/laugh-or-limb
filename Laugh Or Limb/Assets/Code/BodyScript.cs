using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    public Rigidbody2D body, head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.bodyType = RigidbodyType2D.Dynamic; 
            head.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
