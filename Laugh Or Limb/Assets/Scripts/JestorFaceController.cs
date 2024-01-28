using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JestorFaceController : MonoBehaviour
{
    public GameObject neutralFace, hurtFace;
    // Start is called before the first frame update
    void Start()
    {
        neutralFace.SetActive(true);
        hurtFace.SetActive(false);
    }

    private IEnumerator swapFace()
    {
        neutralFace.SetActive(false);
        hurtFace.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        neutralFace.SetActive(true);
        hurtFace.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            StartCoroutine(nameof(swapFace));
        }
    }

}
