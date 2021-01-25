using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] Text SumCostText;
    [SerializeField] Text VarianceText;
    [SerializeField] Text ScoreText;

    public void SetResultText(int sumCost,double variance, int score)
    {
        SumCostText.text = sumCost.ToString("N0");
        VarianceText.text = variance.ToString("N1")+"%";
        ScoreText.text = score.ToString("N0");
    }
}
