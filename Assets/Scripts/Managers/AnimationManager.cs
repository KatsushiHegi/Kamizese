using System;
using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    //フェード
    [SerializeField] Animator FadeAnim;

    //ポップアップ
    [SerializeField] GameObject popProject;
    [SerializeField] GameObject popResult;
    [SerializeField] GameObject popRanking;
    [SerializeField] AudioClip pop;

    //走りモーション
    [SerializeField] GameObject Human;

    /// <summary>
    /// フェードインを再生します
    /// </summary>
    public IEnumerator PlayFadeIn()
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
        FadeAnim.gameObject.SetActive(false);
    }
    /// <summary>
    /// フェードアウトを再生します
    /// </summary>
    public IEnumerator PlayFadeOut(Action callback = null)
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.5f);
        FadeAnim.gameObject.SetActive(false);
        callback?.Invoke();
    }


    /// <summary>
    /// 走りモーションを実行します
    /// </summary>
    public void HumanDash(bool State)
    {
        Animator animator = Human.GetComponent<Animator>();
        AudioSource audioSource = Human.GetComponent<AudioSource>();
        if (State == true){
            animator.SetBool("open",true);
        }
        else{
            animator.SetBool("open",false);
        }
    }
}
