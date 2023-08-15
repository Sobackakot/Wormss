using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSoundController : MonoBehaviour
{
    private bool IsPlayingReclam = true;
    private void OnApplicationFocus(bool hasFocus) //metod unity
    {
        Silence(!hasFocus);
    }
    private void OnApplicationPause(bool isPaused) //metod unity
    {
        Silence(isPaused);
    }
    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        // Or / And
        AudioListener.volume = silence ? 0 : 1;
    }
    private IEnumerator PouseMusicCoroutine() // coroutine
    {
        while (IsPlayingReclam)
        {
            PouseMusic();
            yield return null;
        }
        PlayingMusic();
    }
    public void SwitchMusicButton()
    {
        IsPlayingReclam = true;
        StartCoroutine(PouseMusicCoroutine());
    }
    public void PouseMusic() // metod js
    {
        Silence(true);
        IsPlayingReclam = true;
    }
    public void PlayingMusic() // metod js
    {
        Silence(false);
        IsPlayingReclam = false;
    }
}
