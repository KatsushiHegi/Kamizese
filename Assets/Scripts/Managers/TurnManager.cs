using System;
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
    [SerializeField] PopulationDisplayManager PopulationDisplayManager;
    [SerializeField] ConfirmPopUpManager ConfirmPopUpManager;
    [SerializeField] HumanMoveManager HumanMoveManager;
    [SerializeField] AudioManager AudioManager;
    private void Start() => StartCoroutine(StartTurnThread());
    public void EndTurn() => StartCoroutine(EndTrunThread());
    public void SetText()
    {
        TurnText.text = turn.ToString();
    }

    IEnumerator StartTurnThread()
    {
        if (turn == 11) { 
            StartCoroutine(ResultManager.ResultThread());
            yield break;
        }
        else if (turn > 1)
        {
            PopUpManager.ActiveTurnResultPop();
            TurnRusultManager.Set();
        }
        PopulationDisplayManager.UpdatePopulation();
        ConfirmPopUpManager.Set();
        SetText();
        MoneyManager.SetMoneyText();
        if (turn == 1) StartCoroutine(AudioManager.PlayMainBgm());
        else StartCoroutine(AudioManager.UnPauseMainBgm());
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
        StartCoroutine( AudioManager.PauseMainBgm());
        if (turn == 1) StartCoroutine(AudioManager.PlayMoveBgm());
        else StartCoroutine(AudioManager.UnPauseMoveBgm());
        yield return HumanMoveManager.HumanMove();
        StartCoroutine(AudioManager.PauseMoveBgm());
        yield return AnimationManager.PlayFadeOut();
        turn++;
        StartCoroutine(StartTurnThread());
    }
    public void SkipButtonClick() => StartCoroutine(Skip());
    IEnumerator Skip()
    {
        yield return AnimationManager.PlayFadeOut();
        turn = 10;
        SetText();
        turn = 11;
        StartCoroutine(StartTurnThread());
    }
}
