using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MainBgm;
    [SerializeField] AudioSource MoveBgm;
    [SerializeField] AudioSource ResultBgm;
    [SerializeField] AudioSource OkSe;
    [SerializeField] AudioSource NoSe;

    /// <summary>
    /// OKのSEを再生します
    /// </summary>
    public void PlayOkSe()
    {
        OkSe.Play();
    }
    /// <summary>
    /// NOのSEを再生します
    /// </summary>
    public void PlayNoSe()
    {
        NoSe.Play();
    }

    /// <summary>
    /// MainBGMを再生します
    /// </summary>
    public IEnumerator PlayMainBgm()
    {
        MainBgm.Play();
        yield return FadeIn(MainBgm);
    }

    /// <summary>
    /// MainBGMを停止します
    /// </summary>
    public IEnumerator StopMainBgm()
    {
        yield return FadeOut(MainBgm);
        MainBgm.Stop();
    }

    /// <summary>
    /// MainBGMを一時停止します
    /// </summary>
    public IEnumerator PauseMainBgm()
    {
        yield return Pause(MainBgm);
    }

    /// <summary>
    /// MainBGMを一時停止を解除します
    /// </summary>
    public IEnumerator UnPauseMainBgm()
    {
        yield return UnPause(MainBgm);
    }


    /// <summary>
    /// MoveBGMを再生します
    /// </summary>
    public IEnumerator PlayMoveBgm()
    {
        MoveBgm.Play();
        yield return FadeIn(MoveBgm);
    }
    /// <summary>
    /// MoveBGMを停止します
    /// </summary>
    public IEnumerator StopMoveBgm(Action callbak = null)
    {
        yield return FadeOut(MoveBgm);
        MoveBgm.Stop();
        callbak?.Invoke();
    }
    /// <summary>
    /// MoveBGMを一時停止します
    /// </summary>
    public IEnumerator PauseMoveBgm()
    {
        yield return Pause(MoveBgm);
    }
    /// <summary>
    /// MoveBGMを一時停止を解除します
    /// </summary>
    public IEnumerator UnPauseMoveBgm()
    {
        yield return UnPause(MoveBgm);
    }

    /// <summary>
    /// ResultBGM再生をします
    /// </summary>
    public IEnumerator PlayResultBgm()
    {
        ResultBgm.Play();
        yield return FadeIn(ResultBgm);
    }
    /// <summary>
    /// ResultBGM停止をします
    /// </summary>
    public IEnumerator StopResultBgm(Action callbak = null)
    {
        yield return FadeOut(ResultBgm);
        ResultBgm.Stop();
        callbak?.Invoke();
    }


    /// <summary>
    /// audioをフェードアウトし、一時停止します
    /// </summary>
    IEnumerator Pause(AudioSource audio)
    {
        yield return FadeOut(audio);
        audio.Pause();
    }
    /// <summary>
    /// audioをフェードインし、一時停止します
    /// </summary>
    IEnumerator UnPause(AudioSource audio)
    {
        audio.UnPause();
        yield return FadeIn(audio);
    }
    /// <summary>
    /// audioをフェードインします
    /// </summary>
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
    /// <summary>
    /// audioをフェードアウトします
    /// </summary>
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
