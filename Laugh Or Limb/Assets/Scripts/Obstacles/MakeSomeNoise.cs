using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSomeNoise : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip aSound;

    private bool bSpawn = false;
    public GameObject confettiSpawned, cannon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Hit ?");
        if (collision.gameObject.tag == "Player")
        {
           // Debug.Log("Hit Player");
            aSource.PlayOneShot(aSound);

            confettiSpawned = Instantiate(cannon, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
        }
    }
    
    private IEnumerator destroyCannon()
    {
        if (!bSpawn)
        {
            confettiSpawned.GetComponent<ParticleSystem>().Play();
            bSpawn = true;
        }
        yield return new WaitForSeconds(6f);
        Destroy(confettiSpawned);
        bSpawn = false;
    }
}
