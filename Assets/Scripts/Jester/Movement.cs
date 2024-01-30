using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    PlayerInput pInput;
    [SerializeField]
    private Rigidbody2D rBody;
    [SerializeField]
    private float incSpeed, currSpeed, minSpeed, maxSpeed, retSpeed;
    private bool bAdjust = false, bSlow = false;
    

    private void Start()
    {
        pInput = new PlayerInput();
        pInput.Enable();
    }

    private void Update()
    {
        if(!bAdjust)
        {
            if(pInput.Move.Adjust.ReadValue<Vector2>().x > 0)
            {
                currSpeed = Mathf.Clamp(currSpeed, minSpeed, maxSpeed);
                currSpeed += incSpeed;
               // Debug.Log("Moving Right");
                if(!bAdjust)
                    StartCoroutine(nameof(AdjustSpeed));
            }
            else if(pInput.Move.Adjust.ReadValue<Vector2>().x < 0)
            {
                currSpeed = Mathf.Clamp(currSpeed, minSpeed, maxSpeed);
               currSpeed -= incSpeed;
               //Debug.Log("Moving Left");
                if(!bAdjust)
                    StartCoroutine(nameof(AdjustSpeed));
            }
            else
            {
                if(!bSlow)
                    StartCoroutine(nameof(SlowSpeed));
            }
        }
    }

    private IEnumerator AdjustSpeed()
    {
        bAdjust = true;
        rBody.AddForce(transform.right * currSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        bAdjust = false;
    }
    private IEnumerator SlowSpeed()
    {
        bSlow = true;

        if (currSpeed > 0)
            currSpeed -= retSpeed;
        else if (currSpeed < 0)
            currSpeed += retSpeed;

        yield return new WaitForSeconds(0.3f);
        bSlow = false;
    }
}
