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
    [SerializeField] TurnRusultManager TurnRusultManager;
    [SerializeField] ResultManager ResultManager;
    private void Start() => StartCoroutine(StartTurnThread());
    public void EndTurn() => StartCoroutine(EndTrunThread());
    public void SetText()
    {
        TurnText.text = turn.ToString();
    }
    public void SkipButtonClick() => StartCoroutine(Skip());
    IEnumerator Skip()
    {
        yield return AnimationManager.PlayFadeOut();
        turn = 20;
        SetText();
        turn = 21;
        StartCoroutine(StartTurnThread());
    }
    IEnumerator StartTurnThread()
    {
        if (turn == 21) { 
            StartCoroutine(ResultManager.ResultThread());
            yield break;
        }
        else if (turn > 1)
        {
            PopUpManager.ActiveTurnResultPop();
            TurnRusultManager.Set();
        }
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
        PrefectureManager.UseItems();
        yield return AnimationManager.PlayFadeOut();
        turn++;
        StartCoroutine(StartTurnThread());
    }
    IEnumerator ResultThread()
    {
        Debug.Log("Rusult");
        yield return AnimationManager.PlayFadeIn();
    }
}
