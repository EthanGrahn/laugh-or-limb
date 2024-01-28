using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnT, SpawnM, SpawnB, Projectile;
    private bool bSpawn = false, bFiring = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bSpawn = true;
            StartCoroutine(nameof(FireRate));
            bFiring = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bSpawn = false;
            StopCoroutine(nameof(FireRate));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!bFiring)
        {
            StartCoroutine(nameof(FireRate));
            bFiring = true;
        }
    }

    private IEnumerator FireRate()
    {
        if(bSpawn)
        {
            Instantiate(Projectile, new Vector3(SpawnT.transform.position.x, SpawnT.transform.position.y, SpawnT.transform.position.z), Quaternion.identity);
            Instantiate(Projectile, new Vector3(SpawnM.transform.position.x, SpawnM.transform.position.y, SpawnM.transform.position.z), Quaternion.identity);
            Instantiate(Projectile, new Vector3(SpawnB.transform.position.x, SpawnB.transform.position.y, SpawnB.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            bFiring = false;
        }
    }
}
