using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager instanceAudio { get; private set; }   
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioStart;
    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioJumpEnd;
    [SerializeField] private AudioClip audioFire;
    [SerializeField] private AudioClip audioDamage;
    [SerializeField] private AudioClip audioTroling;
    [SerializeField] private AudioClip audioDead;
    [SerializeField] private AudioClip audioBoom;
    private void Awake()
    {
        if (instanceAudio == null)
        {
            instanceAudio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
            return;
        } 
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {
        PlayStartSound();
    }
    private void PlayStartSound()
    {
        audioSource.PlayOneShot(audioStart);
    }
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(audioJump);
    }
    public void PlayJumpEndSound()
    {
        audioSource.PlayOneShot(audioJumpEnd);
    }
    public void PlayFireSound()
    {
        audioSource.PlayOneShot(audioFire);
    }
    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(audioDamage);
    }
    public void PlayDeadSound()
    {
        audioSource.PlayOneShot(audioDead);
    }
    public void PlayTrolingSound()
    {
        audioSource.PlayOneShot(audioTroling);
    }
    public void PlayBoomSound()
    {
        audioSource.PlayOneShot(audioBoom);
    }
    
}
