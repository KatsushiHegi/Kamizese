using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] PopUpManager PopUpManager;
    [SerializeField] SaveManager SaveManager;
    [SerializeField] ResultController ResultController;
    [SerializeField] RankingController RankingController;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AnimationManager AnimationManager;
    public int sumCost { get; set; } = 0;
    public double variance { get; private set; } = 0;
    public int score { get; private set; } = 0;

    public IEnumerator ResultThread()
    {
        StartCoroutine(AudioManager.StopMainBgm());
        StartCoroutine(AudioManager.PlayResultBgm());
        CalcVariance();
        CalcScore();
        PopUpManager.ActiveResultPop();
        ResultController.SetResultText(sumCost, variance, score);

        yield break;
    }
    public void Ranking()
    {
        PopUpManager.ActiveRankingPop();
        RankingUpdate();
        RankingController.SetRanking(SaveManager.GameConfig.scoreList);
    }

    void RankingUpdate()
    {
        SaveManager.LoadDataFromLocal();
        for (int i = 0; i < SaveManager.GameConfig.scoreList.Count; i++)
        {
            if (SaveManager.GameConfig.scoreList[i] < score)
            {
                SaveManager.GameConfig.scoreList.Insert(i, score);
                SaveManager.GameConfig.scoreList.RemoveAt(SaveManager.GameConfig.scoreList.Count - 1);
                break;
            }
        }
        SaveManager.SaveDataToLocal();
    }
    double CalcVariance()
    {
        double average = 0;
        double variance = 0;
        foreach (PrefectureController pc in PrefectureManager.prefectureControllers)
        {
            average += pc.prefecture.population;
        }
        average /= 47;
        foreach (PrefectureController pc in PrefectureManager.prefectureControllers)
        {
            variance += (pc.prefecture.population - average) * (pc.prefecture.population - average);
        }
        variance /= 47;
        this.variance = variance;
        return variance;
    }
    int CalcScore()
    {
        int score;
        score = (int)(-variance + 117151573);
        Debug.Log("score" + score);
        this.score = score;
        return score;
    }
    public void ToTitleOnClick()
    {
        StartCoroutine(col());
        IEnumerator col()
        {
            int i = 0;
            Action callback = () => i++;
            Action cols = () => StartCoroutine(AnimationManager.PlayFadeOut(callback));
            cols += () => StartCoroutine(AudioManager.StopResultBgm(callback));
            cols.Invoke();
            yield return new WaitUntil(() => i == cols.GetInvocationList().Length);
            SceneManager.LoadScene("title");
        }
    }
}
