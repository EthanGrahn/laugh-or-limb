using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class BodyScript : MonoBehaviour
{
    public Rigidbody2D body, head;
    public float power = 100f;
    public float gravity = 40f;

    private bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -gravity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.bodyType = RigidbodyType2D.Dynamic; 
            head.bodyType = RigidbodyType2D.Dynamic;
        }

        //Launch In direction
        if (Input.GetMouseButtonDown(0) && !launched)
        {
            launched = true;
            body.bodyType = RigidbodyType2D.Dynamic;
            head.bodyType = RigidbodyType2D.Dynamic;

            Vector3 mousePos = Input.mousePosition;
            Vector2 direction = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane)) - body.transform.position;
            direction.Normalize();
            body.AddForce(direction * power, ForceMode2D.Impulse);
        }
    }
}
