using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MainBgm;
    [SerializeField] AudioSource MoveBgm;
    [SerializeField] AudioSource ResultBgm;
    [SerializeField] AudioSource OkSe;
    [SerializeField] AudioSource NoSe;

    public void PlayOkSe()
    {
        OkSe.Play();
    }
    public void PlayNoSe()
    {
        NoSe.Play();
    }

    public IEnumerator PlayMainBgm()
    {
        MainBgm.Play();
        yield return FadeIn(MainBgm);
    }
    public IEnumerator StopMainBgm(Action callbak = null)
    {
        yield return FadeOut(MainBgm);
        MainBgm.Stop();
        callbak?.Invoke();
    }
    public IEnumerator PauseMainBgm()
    {
        yield return Pause(MainBgm);
    }
    public IEnumerator UnPauseMainBgm()
    {
        yield return UnPause(MainBgm);
    }


    public IEnumerator PlayMoveBgm()
    {
        MoveBgm.Play();
        yield return FadeIn(MoveBgm);
    }
    public IEnumerator StopMoveBgm(Action callbak = null)
    {
        yield return FadeOut(MoveBgm);
        MoveBgm.Stop();
        callbak?.Invoke();
    }
    public IEnumerator PauseMoveBgm()
    {
        yield return Pause(MoveBgm);
    }
    public IEnumerator UnPauseMoveBgm()
    {
        yield return UnPause(MoveBgm);
    }

    
    public IEnumerator PlayResultBgm()
    {
        ResultBgm.Play();
        yield return FadeIn(ResultBgm);
    }
    public IEnumerator StopResultBgm(Action callbak = null)
    {
        yield return FadeOut(ResultBgm);
        ResultBgm.Stop();
        callbak?.Invoke();
    }



    IEnumerator Pause(AudioSource audio)
    {
        yield return FadeOut(audio);
        audio.Pause();
    }
    IEnumerator UnPause(AudioSource audio)
    {
        audio.UnPause();
        yield return FadeIn(audio);
    }
    IEnumerator FadeIn(AudioSource audio)
    {
        float fadeInSeconds = 0.5f;
        int maxFlame = (int)(fadeInSeconds * 60);
        float volume = 0.5f;
        for (int i = 0; i < maxFlame; i++)
        {
            audio.volume = volume * (i / (float)maxFlame);
            yield return null;
        }
    }
    IEnumerator FadeOut(AudioSource audio)
    {
        float fadeInSeconds = 0.5f;
        int maxFlame = (int)(fadeInSeconds * 60);
        float volume = 0.5f;

        for (int i = maxFlame - 1; i > 0; i--)
        {
            audio.volume = volume * (i / (float)maxFlame);
            yield return null;
        }
    }
}
