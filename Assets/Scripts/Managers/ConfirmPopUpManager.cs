using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPopUpManager : MonoBehaviour
{
    [SerializeField] Text PrefectureMoveOverviewPrefab;
    [SerializeField] Transform Parent;
    [SerializeField] Button RunButton;
    [SerializeField] PrefectureManager PrefectureManager;
    public void Set()
    {
        foreach (Transform child in Parent)
        {
            Destroy(child.gameObject);
        }
        foreach (PrefectureController p in PrefectureManager.prefectureControllers)
        {
            foreach (Item item in p.prefecture.itemList)
            {
                var i = Instantiate(PrefectureMoveOverviewPrefab, Parent);
                i.GetComponent<MoveOverViewController>().Init(
                    p.prefecture.prefectureName,
                    item.targetPrefecture.prefectureName,
                    new Calc().CalcProbability(item.attractiveness, Vector2.Distance(p.prefecture.coordinate, item.targetPrefecture.coordinate))
                    );
            }
        }
    }

}
