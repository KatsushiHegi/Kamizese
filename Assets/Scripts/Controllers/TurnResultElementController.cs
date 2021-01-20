using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnResultElementController : MonoBehaviour
{
    [SerializeField] Text PrefectureText;
    [SerializeField] Text TargetText;
    [SerializeField] Text PeopleText;
    [SerializeField] Text MoneyText;
    public void Set(string prefectureName, string targetPrefectureName, int people, int money)
    {
        PrefectureText.text = prefectureName;
        TargetText.text = targetPrefectureName;
        PeopleText.text = people.ToString("N0");
        MoneyText.text = money.ToString("N0");
    }
}
