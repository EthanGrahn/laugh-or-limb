using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    private GameObject player;
    private bool bFroze = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!bFroze)
        {
            bFroze = true;
            //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //   collision.gameObject.GetComponent<Rigidbody2D>().totalForce = new Vector2(0, 0);
            if (collision.gameObject.tag == "Player") ;
                player = collision.gameObject;

            StartCoroutine(nameof(freezer));
        }

    }

    private IEnumerator freezer()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1f);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
