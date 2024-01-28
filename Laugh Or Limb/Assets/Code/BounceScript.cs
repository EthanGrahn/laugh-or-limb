using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    [SerializeField]
    private float pushForce;
    [SerializeField]
    private bool bVert;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * pushForce, ForceMode2D.Impulse);
        }
    }
}
