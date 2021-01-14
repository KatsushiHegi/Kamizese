using System.Collections.Generic;
using UnityEngine;

public class Prefecture
{
    public int prefectureId;
    public string prefectureName;
    public int population;
    public Vector2 coordinate;
    public List<Item> itemList = new List<Item>();
    public void SetPrefecture(int prefectureId, string prefectureName, Vector2 coordinate)
    {
        this.prefectureId = prefectureId;
        this.prefectureName = prefectureName;
        this.coordinate = coordinate;
    }
}