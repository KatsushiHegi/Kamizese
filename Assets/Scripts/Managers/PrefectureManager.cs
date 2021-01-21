using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrefectureManager : MonoBehaviour
{
    public PrefectureController[] prefectureControllers = new PrefectureController[47];
    [SerializeField] MoneyManager MoneyManager;
    [SerializeField] TurnRusultManager TurnRusultManager;
    private void Awake()
    {
        Allocation();

        void Allocation()
        {
            CSVReader cSVReader = new CSVReader();
            cSVReader.SetPrefectureInfo();
            for (int i = 0; i < prefectureControllers.Length; i++)
            {
                prefectureControllers[i].prefecture.SetPrefecture(
                    int.Parse(cSVReader.prefectureCsvData[i][0]),
                    cSVReader.prefectureCsvData[i][1],
                    new Vector2(float.Parse(cSVReader.prefectureCsvData[i][2]), float.Parse(cSVReader.prefectureCsvData[i][3])),
                    new Calc().ProbabilityToPopulation(float.Parse(cSVReader.prefectureCsvData[i][4]))
                    );
            }
        }
    }
    public Prefecture GetPrefecture(int prefectureId)
    {
        return prefectureControllers[prefectureId].prefecture;
    }
    public void UseItems()
    {
        foreach (PrefectureController ps in prefectureControllers)
        {
            foreach (Item i in ps.prefecture.itemList )
            {
                int people = ps.prefecture.UseItem(i);
                int money = MoneyManager.GetRewarded(people, Vector2.Distance(ps.prefecture.coordinate, i.targetPrefecture.coordinate));
                TurnRusultManager.dispDataList.Add(
                    new DispData()
                    {
                        prefectureName = ps.prefecture.prefectureName,
                        targetPrefectureName = i.targetPrefecture.prefectureName,
                        peopleToMove = people,
                        reward = money
                    }) ;
            }
        }
    }

}
