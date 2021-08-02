using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveManager : MonoBehaviour
{
    [SerializeField] GameObject HumanPref;
    [SerializeField] Transform Parent;
    [SerializeField] GameObject Panel;
    //47都道府県の座標
    Vector2[] coordinateList = new Vector2[47];
    public List<MoveData> moveDataList { get; set; } = new List<MoveData>();
    private void Start()
    {
        var csv = new CSVReader();
        csv.SetCoordinateInfo();
        for (int i = 0; i < csv.coordinateCsvData.Count; i++)
        {
            coordinateList[i] = new Vector2(int.Parse(csv.coordinateCsvData[i][0]), int.Parse(csv.coordinateCsvData[i][1]));
        }
    }
    /// <summary>
    /// Humanオブジェクトを生成し移動を実行します
    /// </summary>
    public IEnumerator HumanMove()
    {
        const int humanRatio = 500;
        int count = 0;
        int finishCount = 0;
        Panel.SetActive(true);
        foreach (MoveData md in moveDataList)
        {
            for (int i = 0; i < md.population; i += humanRatio)
            {
                var ins = Instantiate(HumanPref, Parent);
                ins.GetComponent<HumanController>().Move(
                    coordinateList[md.sourceId],
                    coordinateList[md.targetId],
                    () => finishCount++
                    );
                count++;
            }
        }
        yield return new WaitUntil(() => finishCount == count);
        moveDataList.Clear();
        Panel.SetActive(false);
    }
}
public struct MoveData
{
    public int sourceId;
    public int targetId;
    public int population;
}
