using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOverViewController : MonoBehaviour
{
    public void Init(string prefectureName, string toPrefectureName, double probability){
        GetComponent<Text>().text = prefectureName + "->" + toPrefectureName + "　" + (probability * 100).ToString("f1");
    }
}
