using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefectureManager : MonoBehaviour
{
    [SerializeField] PrefectureController[] prefectures = new PrefectureController[47];
    private void Start()
    {
        AllocationId();

        void AllocationId()
        {
            for (int i = 0; i < prefectures.Length; i++)
            {
                prefectures[i].prefecture.prefectureId = i;
            }
        }
    }

    public Prefecture GetPrefecture(int prefectureId)
    {
        return prefectures[prefectureId].prefecture;
    }
}
