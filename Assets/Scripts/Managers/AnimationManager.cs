using System.Collections;
using System.Collections.Generic;
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

    //フェード
    public IEnumerator PlayFadeIn()
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
        FadeAnim.gameObject.SetActive(false);
    }
    public IEnumerator PlayFadeOut()
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.5f);
        FadeAnim.gameObject.SetActive(false);
    }

    //ポップアップ
    //プロジェクト
    public void popProjectOn()
    {
        popProject.SetActive(true);
    }
    public IEnumerator popProjectOff(){
        Animator animator = popProject.GetComponent<Animator>();
        AudioSource audioSource = popProject.GetComponent<AudioSource>();
        animator.SetBool("open",false);
        audioSource.PlayOneShot(pop);
        yield return new WaitForSeconds(.5f);
        popProject.SetActive(false);
    }

    //リザルト
    public void popResultOn()
    {
        popResult.SetActive(true);
    }
    public IEnumerator popResultOff(){
        Animator animator = popResult.GetComponent<Animator>();
        AudioSource audioSource = popResult.GetComponent<AudioSource>();
        animator.SetBool("open",false);
        audioSource.PlayOneShot(pop);
        yield return new WaitForSeconds(.5f);
        popResult.SetActive(false);
    }

    //ランキング
    public void popRankingOn()
    {
        popRanking.SetActive(true);
    }
    public IEnumerator popRankingOff(){
        Animator animator = popRanking.GetComponent<Animator>();
        AudioSource audioSource = popRanking.GetComponent<AudioSource>();
        animator.SetBool("open",false);
        audioSource.PlayOneShot(pop);
        yield return new WaitForSeconds(.5f);
        popRanking.SetActive(false);
    }

    //走りモーション
    public void HumanDash(bool State)
    {
        Animator animator = Human.GetComponent<Animator>();
        AudioSource audioSource = Human.GetComponent<AudioSource>();
        if (State = true){
            animator.SetBool("open",true);
        }
        else{
            animator.SetBool("open",false);
        }
    }
}
