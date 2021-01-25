using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMain : MonoBehaviour
{
    [SerializeField] AudioSource Bgm;
    [SerializeField] Animator FadeAnim;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(

            () => GoToMain()
            ) ;
    }
    void GoToMain()
    {
        StartCoroutine(col());
        IEnumerator col()
        {
            StartCoroutine(FadeOut(Bgm));
            yield return PlayFadeOut();
            SceneManager.LoadScene("Main");
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
    IEnumerator PlayFadeOut(Action callback = null)
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.5f);
        callback?.Invoke();
    }
}
