using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LimbColliders : MonoBehaviour
{
    public delegate void HitBounce(string trap);
    public event HitBounce hitBounce;
    public UnityEvent<string> OnLimbHit = new UnityEvent<string>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != null && collision.gameObject.tag != "Player")
        {
            OnLimbHit.Invoke(collision.gameObject.tag);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
