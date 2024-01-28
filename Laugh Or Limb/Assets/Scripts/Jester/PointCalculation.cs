using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;
using System.Linq;

public class PointCalculation : MonoBehaviour
{
    PointsDisplay pDisplay;
    /*
     * use tags for multiplier? traps are 2X floor is 0.5X walls are 1X
     * use velocity as the base value
     * calculate per limb? limbs have different values?
     */

    [SerializeField]
    private float limbScore, fTemp;
    private int iPoints;
    private Rigidbody2D rBody;

    public UnityEvent<float> OnBoardUpdate = new UnityEvent<float>();
    public UnityEvent<float> OnDecay = new UnityEvent<float>();

    List<int> pointStack = new List<int>();

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       // Debug.Log("Collided");
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Trap" || other.gameObject.tag == "Bounce")
        {
            fTemp = rBody.velocity.magnitude * limbScore;
            if (other.gameObject.tag == "Trap")
            {
                fTemp *= 2;
            }

            iPoints = Mathf.CeilToInt(fTemp);

            //Add and Decay points
            pointStack.Add(iPoints);
            StreamUI.Instance.AddPoints(iPoints);
            StartCoroutine(nameof(pointDecay));

            //send iPoints to the chatmeter

            //send to scoreBoard
            OnBoardUpdate.Invoke(fTemp);
        }
    }

    private IEnumerator pointDecay()
    {
        yield return new WaitForSeconds(0.5f);
        OnDecay.Invoke(pointStack.Sum());
        pointStack.RemoveAt(pointStack.Count - 1);
    }
}
