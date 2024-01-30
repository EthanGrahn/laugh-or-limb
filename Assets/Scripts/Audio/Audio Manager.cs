using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public struct AudioMap
    {
        public string sceneName;
        public AudioClip clip;
        [Range(0, 1)]
        public float volume;
    }

    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    public List<AudioMap> sceneMusic = new List<AudioMap>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            OnLevelWasLoaded(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    private void OnLevelWasLoaded(int level)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        foreach(AudioMap map in sceneMusic)
        {
            if (sceneName == map.sceneName)
            {
                _musicSource.clip = map.clip;
                _musicSource.volume = map.volume;
                _musicSource.Play();
                break;
            }
        }
    }
}
