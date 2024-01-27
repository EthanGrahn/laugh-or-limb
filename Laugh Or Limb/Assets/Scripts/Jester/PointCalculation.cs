using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject displayer;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       // Debug.Log("Collided");
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Trap")
        {
            fTemp = rBody.velocity.magnitude * limbScore;
            if (other.gameObject.tag == "Trap")
            {
                fTemp *= 2;
                Debug.Log("hit trap!");
            }
            else Debug.Log("hit wall :)");
            iPoints = (int)fTemp;
            //send iPoints to a display script
            displayer.GetComponent<PointsDisplay>().updateDisplay(iPoints);

            //send iPoints to the chatmeter
        }
    }
}
