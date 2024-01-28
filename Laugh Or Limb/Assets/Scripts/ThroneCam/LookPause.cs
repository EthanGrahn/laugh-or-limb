using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class LookPause : MonoBehaviour
{
    private CinemachineDollyCart cart;
    private bool hasPaused = false;

    public static Action OPENDOORS = delegate { };

    private void OnEnable()
    {
        cart = GetComponent<CinemachineDollyCart>();
    }
    void Update()
    {
        if (cart.m_Position >= 1 && cart.m_Position < 2 && !hasPaused)
        {
            cart.m_Speed = 0;
            cart.m_Position = 1;
            hasPaused = true;
        }
        if(cart.m_Position == 3)
        {
            OPENDOORS();
        }
    }
}
