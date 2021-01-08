using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] AnimationManager AnimationManager;
    private void Start()
    {
        StartCoroutine(StartTurnThread());
    }
    public void EndTurn() => StartCoroutine(EndTrunThread());
    IEnumerator StartTurnThread()
    {
        yield return AnimationManager.PlayFadeIn();
    }
    IEnumerator EndTrunThread()
    {
        yield return AnimationManager.PlayFadeOut();
    }
}
