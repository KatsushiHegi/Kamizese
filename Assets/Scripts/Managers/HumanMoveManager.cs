using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveManager : MonoBehaviour
{
    [SerializeField] GameObject HumanPref;
    [SerializeField] Transform Parent;
    public List<MoveData> moveDataList { get; set; } = new List<MoveData>();
    public IEnumerator HumanMove()
    {
        int count = 0;
        int finishCount = 0;
        foreach (MoveData md in moveDataList)
        {
            for (int i = 0; i < md.population; i+=10)
            {
                var ins = Instantiate(HumanPref, Parent);
                ins.GetComponent<HumanController>().Move(
                    md.sourceCoordinate,
                    md.targetCoordinate,
                    () => { finishCount++; }
                    );
                count++;
            }
        }
        while (count == finishCount)
        {
            yield return null;
        }
        moveDataList.Clear();
    }
}
public struct MoveData
{
    public Vector2 sourceCoordinate;
    public Vector2 targetCoordinate;
    public int population;
}
