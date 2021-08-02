using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefectureSelectController : MonoBehaviour
{
    [SerializeField] Text selectedPrefectureText;
    private void Start()
    {
        selectedPrefectureText.text = "";
    }
    /// <summary>
    /// 選択中の都道府県名を表示します
    /// </summary>
    /// <param name="prefectureName">都道府県名</param>
    public void SetSelectedPrefectureText(string prefectureName) {
        selectedPrefectureText.text = prefectureName;
    }
}
