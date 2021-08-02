using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationDisplayElementController : MonoBehaviour
{
    [SerializeField] Text PrefectureText;
    [SerializeField] Text PopulationText;

    /// <summary>
    /// 都道府県名を表示します
    /// </summary>
    /// <param name="prefectureName">都道府県名</param>
    /// <param name="textColor">テキストの色</param>
    public void SetPrefectureText(string prefectureName, Color textColor){
        PrefectureText.text = prefectureName;
        PrefectureText.color = textColor;
    }
    /// <summary>
    /// 人口を表示します
    /// </summary>
    /// <param name="population">人口</param>
    /// <param name="textColor">テキストの色</param>
    public void SetPopulationText(int population, Color textColor){
        PopulationText.text = population.ToString("N0")+"千人";
        PopulationText.color = textColor;
    }
}
