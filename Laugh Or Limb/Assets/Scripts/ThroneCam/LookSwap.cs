using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookSwap : MonoBehaviour
{
    private CinemachineDollyCart cart;
    [SerializeField]
    private CinemachineVirtualCamera cam;
    [SerializeField]
    private CinemachineDollyCart lookAtTarget;
    private bool hasPaused = false;
    public bool dropTime = false;

    private void Start()
    {
        cart = GetComponent<CinemachineDollyCart>();
    }

    void Update()
    {
        if(cart.m_Position >= 1 && cart.m_Position <2)
        {
            cam.LookAt = lookAtTarget.transform;
            lookAtTarget.m_Speed = .5f;
        }
        else if(cart.m_Position >=2 && !hasPaused)
        {
            cart.m_Speed = 0;
            hasPaused = true;

            //replace this with king dialogue
            StartCoroutine(nameof(waitTime),5);

        }
        else if(cart.m_Position >= 2 && dropTime)
        {
            //cart.m_Speed = .5f;
            //lookAtTarget.m_Speed = 1.5f;
        }
    }

    IEnumerator waitTime(int delay)
    {
        yield return new WaitForSeconds(delay);
        dropTime = true;
    }
}
