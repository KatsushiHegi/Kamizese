using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] AnimationManager AnimationManager;
    IEnumerator StartTurnThread()
    {
        yield return AnimationManager.PlayFadeIn();
    }
    IEnumerator EndTrunThread()
    {
        yield return AnimationManager.PlayFadeOut();
    }
}
