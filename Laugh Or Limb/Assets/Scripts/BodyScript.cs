using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class BodyScript : MonoBehaviour
{
    public Rigidbody2D body, head;

    public GameObject normalFace, hurtFace;

    public float power = 100f;
    public float gravity = 40f;
    float mouseDownTimer;

    private bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -gravity);
        normalFace.SetActive(true);
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

    private IEnumerator swapFace()
    {
        normalFace.SetActive(false);
        hurtFace.SetActive(true);
        yield return new WaitForSeconds(0.5f); 
        normalFace.SetActive(true);
        hurtFace.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            body.AddForce(transform.up * power / 2, ForceMode2D.Impulse);
        }
        StartCoroutine(nameof(swapFace));
        /*
        if (collision.gameObject.tag != "Player")
        {
            StartCoroutine(nameof(swapFace));
        }
        */
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

        if (!launched)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetMouseButtonUp(0))
            {
                launched = true;
                body.bodyType = RigidbodyType2D.Dynamic;
                head.bodyType = RigidbodyType2D.Dynamic;

                body.AddForce(this.transform.right * Mathf.Min((Time.time - mouseDownTimer) * 1000, power), ForceMode2D.Impulse);
            }
        }
    }
}
