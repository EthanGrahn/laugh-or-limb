using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip clip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter()
    {
        audioSource.PlayOneShot(clip, 0.7F);
    }
}
