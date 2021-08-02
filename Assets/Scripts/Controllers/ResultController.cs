using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] Text SumCostText;
    [SerializeField] Text VarianceText;
    [SerializeField] Text ScoreText;

    /// <summary>
    /// リザルトを表示します
    /// </summary>
    /// <param name="sumCost">合計コスト</param>
    /// <param name="variance">分散の値</param>
    /// <param name="score">スコア</param>
    public void SetResultText(int sumCost,double variance, int score)
    {
        SumCostText.text = sumCost.ToString("N0");
        VarianceText.text = variance.ToString("N1")+"%";
        ScoreText.text = score.ToString("N0");
    }
}
