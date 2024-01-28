using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class LookSwap : MonoBehaviour
{
    private Transform initialLook;
    private CinemachineDollyCart cart;
    [SerializeField]
    private CinemachineVirtualCamera cam;
    [SerializeField]
    private CinemachineDollyCart lookAtTarget;
    private bool hasPaused = false;
    public bool dropTime = false;
    private bool hasSwapped = false;

    public static Action beginDialogue = delegate { };
    public static Action endDialogue = delegate { };
    private void Start()
    {
        cart = GetComponent<CinemachineDollyCart>();
        initialLook = cam.LookAt;
        endDialogue += Drop;
    }

    private void OnDisable()
    {
        endDialogue -= Drop;
    }

    void Update()
    {
        if(cart.m_Position >= 1 && cart.m_Position <2 && !hasSwapped)
        {
            cam.LookAt = lookAtTarget.transform;
            lookAtTarget.m_Speed = .5f;
            hasSwapped = true;
        }
        else if(cart.m_Position >=2 && !hasPaused)
        {
            cart.m_Speed = 0;
            hasPaused = true;

            beginDialogue();
            //StartCoroutine(nameof(waitTime), 5); analog for king dialogue
        }
        else if(cart.m_Position >= 2 && dropTime)
        {
            cart.m_Speed = .2f;
            lookAtTarget.m_Speed = 1.5f;
        }
        if(cart.m_Position > 2.5)
        {
            cam.LookAt = initialLook;
        }
    }

    private void Drop()
    {
        dropTime = true;
    }

    IEnumerator waitTime(int delay)
    {
        yield return new WaitForSeconds(delay);
        dropTime = true;
    }
}