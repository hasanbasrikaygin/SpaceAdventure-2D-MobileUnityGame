using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    AudioSource musicSource;
    void Awake()
    {
        Singleton();
        musicSource = GetComponent<AudioSource>();
    }

    private void Singleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    public void MusicPlay(bool play)
    {
        if(play)
        {
            if(!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
        }
    }
}
