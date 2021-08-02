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
    /// <summary>
    /// ターン毎のリザルトの要素を用意します
    /// </summary>
    /// <param name="prefectureName">移動前都道府県名</param>
    /// <param name="targetPrefectureName">移動後都道府県名</param>
    /// <param name="people">人数</param>
    /// <param name="money">報酬金額</param>
    public void Set(string prefectureName, string targetPrefectureName, int people, int money)
    {
        PrefectureText.text = prefectureName;
        TargetText.text = targetPrefectureName;
        PeopleText.text = people.ToString("N0");
        MoneyText.text = money.ToString("N0");
    }
}
