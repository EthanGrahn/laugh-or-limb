using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LimbColliders : MonoBehaviour
{
    public delegate void HitBounce(string trap);
    public UnityEvent<Collision2D> OnLimbHit = new UnityEvent<Collision2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != null && collision.gameObject.tag != "Player")
        {
            OnLimbHit.Invoke(collision);
        }
    }
}
