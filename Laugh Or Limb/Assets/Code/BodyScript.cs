using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class BodyScript : MonoBehaviour
{
    public Rigidbody2D body, head;
    public BoxCollider2D R_leg, L_leg;
    public float power = 100f;
    public float gravity = 40f;
    float mouseDownTimer;

    private bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -gravity);
    }

    public void trapIncounter(Collision2D trap)
    {
        if (trap == null)
        {
            return;
        }
        if (trap.gameObject.tag == "Bounce")
        {
            Transform pad = trap.gameObject.transform;

            body.AddForce(pad.up * power / 10f, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            body.AddForce(transform.up * power / 2, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.bodyType = RigidbodyType2D.Dynamic; 
            head.bodyType = RigidbodyType2D.Dynamic;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownTimer = Time.time;
        }

        //Launch In direction
        if (Input.GetMouseButtonUp(0) && !launched)
        {
            launched = true;
            body.bodyType = RigidbodyType2D.Dynamic;
            head.bodyType = RigidbodyType2D.Dynamic;

            Vector3 mousePos = Input.mousePosition;
            Vector2 direction = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane)) - body.transform.position;
            direction.Normalize();
            body.AddForce(direction * Mathf.Min((Time.time - mouseDownTimer) * 1000, power), ForceMode2D.Impulse);
            Debug.Log((Time.time - mouseDownTimer) * 1000);
        }
    }
}
