using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnRusultManager : MonoBehaviour
{
    public List<DispData> dispDataList { get; set; } = new List<DispData>();
    [SerializeField] GameObject TurnResultElementPref;
    [SerializeField] Transform parent;
    public void Set()
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
        foreach (DispData dd in dispDataList)
        {
            var i = Instantiate(TurnResultElementPref, parent);
            i.GetComponent<TurnResultElementController>().Set(dd.prefectureName, dd.targetPrefectureName, dd.peopleToMove, dd.reward);
        }
    }
}
public struct DispData
{
    public string prefectureName;
    public string targetPrefectureName;
    public int peopleToMove;
    public int reward;
}
