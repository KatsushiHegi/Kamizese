﻿using System.Collections.Generic;
using UnityEngine;

public class Prefecture
{
    public int prefectureId;
    public int ruralId;
    public string prefectureName;
    public int population;
    public int peopleToMove;
    public Vector2 coordinate;
    public List<Item> itemList = new List<Item>();
    /// <summary>
    /// Prefectureクラスの初期化をします
    /// </summary>
    /// <param name="prefectureId">都道府県ID</param>
    /// <param name="ruralId">地方ID</param>
    /// <param name="prefectureName">都道府県名</param>
    /// <param name="coordinate">座標</param>
    /// <param name="population">人口</param>
    public void SetPrefecture(int prefectureId, int ruralId, string prefectureName, Vector2 coordinate, int population)
    {
        this.prefectureId = prefectureId;
        this.ruralId = ruralId;
        this.prefectureName = prefectureName;
        this.coordinate = coordinate;
        this.population = population;
    }
    /// <summary>
    /// 都道府県に対してItemを使用します
    /// </summary>
    /// <returns>変化した人数を返します</returns>
    public int UseItem(Item item)
    {
        int sum = 0;
        double prob = new Calc().CalcProbability(item.attractiveness, Vector2.Distance(coordinate, item.targetPrefecture.coordinate));
        for (int i = 0; i < population; i++)
        {
            sum += Random.value <= prob ? 1 : 0;
        }
        item.targetPrefecture.population += sum;
        population -= sum;
        return sum;
    }
}