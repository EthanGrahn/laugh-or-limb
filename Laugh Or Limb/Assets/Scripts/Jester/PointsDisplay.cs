using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
   // public GameObject pointDislayer;
    //public TMPro.TMP_Text DisplayScore;
    public UnityEvent<int> OnPointsGained = new UnityEvent<int>();
    [SerializeField]
    int currPoints;

    public void updateDisplay(int points)
    {
        StopCoroutine(nameof(resetDisplay));
        //if (DisplayScore.enabled == false)
        //{
        //    DisplayScore.enabled = true;
        //}
        currPoints += points;
        OnPointsGained.Invoke(points);
        //DisplayScore.text = currPoints.ToString();
        StartCoroutine(nameof(resetDisplay));
    }

    private IEnumerator resetDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        currPoints = 0;
        //DisplayScore.enabled = false;
    }
}
