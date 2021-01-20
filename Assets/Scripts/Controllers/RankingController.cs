using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingController : MonoBehaviour
{
    [SerializeField] Text[] ScoreTexts = new Text[3];

    public void SetRanking(List<int> scoreList)
    {
        for (int i = 0; i < ScoreTexts.Length; i++)
        {
            ScoreTexts[i].text = scoreList[i].ToString("N0");
        }
    }
}
