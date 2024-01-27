using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private float endRotation;
    [SerializeField]
    private AnimationCurve aCurve;
    [SerializeField]
    private float speed;

    public static Action Fall = delegate { };
    private void OnEnable()
    {
        LookPause.OPENDOORS += Open;
    }

    private void OnDisable()
    {
        LookPause.OPENDOORS -= Open;
    }

    private void Open()
    {
        StartCoroutine(nameof(AnimateDoors));
    }

    float x = 0;
    IEnumerator AnimateDoors()
    {
        yield return new WaitForSeconds(2);
        while(x < 1)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(endRotation, 0, 0), aCurve.Evaluate(x));
            x += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2);
        Fall();
    }
}
