using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationDisplayElementController : MonoBehaviour
{
    [SerializeField] Text PrefectureText;
    [SerializeField] Text PopulationText;

    public void SetPrefectureText(string prefectureName, Color textColor){
        PrefectureText.text = prefectureName;
        PrefectureText.color = textColor;
    }

    public void SetPopulationText(int population, Color textColor){
        PopulationText.text = population.ToString("N0")+"千人";
        PopulationText.color = textColor;
    }
}
