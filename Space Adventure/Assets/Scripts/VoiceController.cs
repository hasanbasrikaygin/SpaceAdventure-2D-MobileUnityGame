using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip gold;
    public AudioClip gameOver;
    public AudioClip rocket;
    public AudioClip shield;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpVoice()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }
    public void GoldVoice()
    {
        audioSource.clip = gold;
        audioSource.Play();
    }
    public void GameOverVoice()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
    public void ShieldVoice()
    {
        audioSource.clip = shield;
        audioSource.Play();
    }
    public void RocketVoice()
    {
        audioSource.clip = rocket;
        audioSource.Play();
    }
}
