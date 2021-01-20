using System.Collections.Generic;
using UnityEngine;

public class Prefecture
{
    public int prefectureId;
    public string prefectureName;
    public int population;
    public int peopleToMove;
    public Vector2 coordinate;
    public List<Item> itemList = new List<Item>();
    public void SetPrefecture(int prefectureId, string prefectureName, Vector2 coordinate, int population)
    {
        this.prefectureId = prefectureId;
        this.prefectureName = prefectureName;
        this.coordinate = coordinate;
        this.population = population;
    }
    public int UseItem(Item item)
    {
        int sum = 0;
        double prob = new Calc().CalcProbability(item.attractiveness, Vector2.Distance(coordinate, item.targetPrefecture.coordinate));
        for (int i = 0; i < population; i++)
        {
            sum += Random.value <= prob ? 1 : 0;
        }
        return sum;
    }
}