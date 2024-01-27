using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    bool bFly;
    public int speed;
    public Rigidbody2D rBody;
    private void OnEnable()
    {
        bFly = true;
    }
    void Update()
    {
        if(bFly)
        {
            //rBody.AddForce(transform.right * speed, ForceMode2D.Force);
            transform.position += transform.right * speed * Time.deltaTime;
            //transform.position += new Vector3(speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Player")
        {
          //  collision.gameObject.transform.SetParent(this.gameObject.transform);
            StartCoroutine(nameof(stopper));
        }
    }

    private IEnumerator stopper()
    {
        yield return new WaitForSeconds(3f);
        bFly = false;
    }
}
