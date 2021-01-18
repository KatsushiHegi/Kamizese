using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int turn { get; private set; } = 1;
    [SerializeField] Text TurnText;
    [SerializeField] AnimationManager AnimationManager;
    [SerializeField] MoneyManager MoneyManager;
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] PopUpManager PopUpManager;
    private void Start() => StartCoroutine(StartTurnThread());
    public void EndTurn() => StartCoroutine(EndTrunThread());
    public void SetText()
    {
        TurnText.text = turn.ToString();
    }
    IEnumerator StartTurnThread()
    {
        if (turn == 20) StartCoroutine(ResultThread());
        SetText();
        MoneyManager.SetMoneyText();
        yield return AnimationManager.PlayFadeIn();
    }
    IEnumerator EndTrunThread()
    {
        if (!MoneyManager.Liquidation())
        {
            PopUpManager.ActiveCostPop();
            yield break;
        }
        yield return AnimationManager.PlayFadeOut();
        turn++;
        StartCoroutine(StartTurnThread());
    }
    IEnumerator ResultThread()
    {
        Debug.Log("20");
        yield break;
    }
}
