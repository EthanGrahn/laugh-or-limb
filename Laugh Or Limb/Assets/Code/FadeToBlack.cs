using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeToBlack : MonoBehaviour
{

    public Image BlackOutSquare;

    public bool fade = true;

    void Start()
    {
        StartCoroutine(FadeBlackOutSquare());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeBlackOutSquare());
        }
    }


    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = BlackOutSquare.color;
        float fadeAmount;

        if (BlackOutSquare.color.a > 0)
        {
            while (BlackOutSquare.color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackOutSquare.color = objectColor;
                yield return null;
            }

            fade = false;
        } else
          {
            while (BlackOutSquare.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackOutSquare.color = objectColor;
                yield return null;
            }

          }





    }
}