using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator FadeAnim;
    public IEnumerator PlayFadeIn()
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator PlayFadeOut()
    {
        FadeAnim.gameObject.SetActive(true);
        FadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.5f);
    }
}
