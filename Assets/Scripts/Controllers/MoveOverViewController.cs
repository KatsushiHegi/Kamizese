using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOverViewController : MonoBehaviour
{
    /// <summary>
    /// 移動概要を表示します
    /// </summary>
    /// <param name="prefectureName">移動前都道府県名</param>
    /// <param name="toPrefectureName">移動後都道府県名</param>
    /// <param name="probability">確率</param>
    public void Init(string prefectureName, string toPrefectureName, double probability){
        GetComponent<Text>().text = prefectureName + "->" + toPrefectureName + "　" + (probability * 100).ToString("f1")+"%";
    }
}
