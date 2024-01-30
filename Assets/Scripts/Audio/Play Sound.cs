using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;

    void Start()
    {
        AudioManager.Instance.PlaySound(_clip);

    }

}
