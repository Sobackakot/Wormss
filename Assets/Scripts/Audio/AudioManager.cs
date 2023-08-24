using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager instanceAudio { get; private set; }   

    [SerializeField]private AudioSource audioSource;
    [SerializeField] private AudioClip audioStart;
    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioJumpEnd;
    [SerializeField] private AudioClip audioFire;
    [SerializeField] private AudioClip audioDamage;
    [SerializeField] private AudioClip audioTroling;
    [SerializeField] private AudioClip audioDead;
    [SerializeField] private AudioClip audioBoom;

    [SerializeField] private Slider voicesVolumeSlider;
    [SerializeField] private float _volume = 1;

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
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void SetVoisVolume(float volume)
    {
        _volume = volume;
    }
    public void Start()
    {
        PlayStartSound();
    }
    public void Update()
    {
        _volume = voicesVolumeSlider.value;
        audioSource.volume = _volume;
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
