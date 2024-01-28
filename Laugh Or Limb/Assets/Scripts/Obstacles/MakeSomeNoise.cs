using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSomeNoise : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip aSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit ?");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            aSource.PlayOneShot(aSound);
        }
    }
}
