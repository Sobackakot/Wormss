using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichMusic : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] audioArray; 

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private float _volumeMus = 1;

    private int index = 0;

    private void Awake()
    {
        m_AudioSource = gameObject.AddComponent<AudioSource>();
    }

    private IEnumerator Start()
    {
        PlayNextMusic();
        yield return null;
    }
    private void Update()
    {
        _volumeMus = musicVolumeSlider.value;
        m_AudioSource.volume = _volumeMus;
    }

    private void PlayNextMusic()
    {
        m_AudioSource.PlayOneShot(audioArray[index]);
    }
    public void PouseMusic()
    {
        enabled = false;
        m_AudioSource.Stop();
    }
    public void PlayingMusic()
    {
        enabled = true;
        m_AudioSource.Play();
    }
    public void SetMusicVolume(float volume)
    {
        _volumeMus = volume;
    }
}