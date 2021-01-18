using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefectureManager : MonoBehaviour
{
    public PrefectureController[] prefectureControllers = new PrefectureController[47];
    private void Start()
    {
        Allocation();

        void Allocation()
        {
            int a = 0;
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
                a += prefectureControllers[i].prefecture.population;
                Debug.Log(prefectureControllers[i].prefecture.population);
            }
            Debug.Log(a);
        }
    }

    public Prefecture GetPrefecture(int prefectureId)
    {
        return prefectureControllers[prefectureId].prefecture;
    }
}
