using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField]
    private float pushForce;
    [SerializeField]
    private bool bVert;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (bVert)
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * pushForce, ForceMode2D.Impulse);
            else
               other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * pushForce, ForceMode2D.Impulse);

            other.gameObject.GetComponent<Rigidbody2D>().AddForce((other.transform.position - this.gameObject.transform.position).normalized * pushForce, ForceMode2D.Impulse);
        }
    }

}
