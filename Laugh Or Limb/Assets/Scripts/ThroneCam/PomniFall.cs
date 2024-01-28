using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PomniFall : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    private void OnEnable()
    {
        OpenDoor.Fall += Fall;
    }

    private void OnDisable()
    {
        OpenDoor.Fall -= Fall;
    }

    private void Fall(bool calling)
    {
        if (calling)
        {
            var rb = GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rigidbody in rb)
            {
                rigidbody.simulated = true;
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
            StartCoroutine(nameof(fade));
        }
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(2);
        LookSwap.fade();
        yield return new WaitUntil(()=> fadeImage.GetComponent<FadeToBlack>().fade == false);
        var index = SceneManager.GetSceneByName("TheFungeon").buildIndex;
        if(index >= 0) SceneManager.LoadScene(index);
    }
}