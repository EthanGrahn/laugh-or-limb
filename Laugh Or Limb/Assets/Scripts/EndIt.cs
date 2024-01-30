using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndIt : MonoBehaviour
{
    private bool hasEnded = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasEnded)
            return;
        if (collision.gameObject.CompareTag("FungeonBottom"))
        {
            StartCoroutine(WaitToEnd());
        }
    }

    private IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("EndScreen");
    }
}
