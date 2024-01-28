using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookPause : MonoBehaviour
{
    private CinemachineDollyCart cart;
    private bool hasPaused = false;

    private void OnEnable()
    {
        cart = GetComponent<CinemachineDollyCart>();
    }
    void Update()
    {
        Debug.Log(hasPaused);
        if (cart.m_Position >= 1 && cart.m_Position < 2 && !hasPaused)
        {
            cart.m_Speed = 0;
            cart.m_Position = 1;
            hasPaused = true;
        }
    }
}
