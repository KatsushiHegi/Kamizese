using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader
{
    public List<string[]> itemCsvData { get; private set; } = new List<string[]>();
    public List<string[]> prefectureCsvData { get; private set; } = new List<string[]>();
    public void SetItemInfo()
    {
        Load("ItemInfo", itemCsvData);
    }
    public void SetPrefectureInfo()
    {
        Load("PrefectureInfo", prefectureCsvData);
    }
    void Load(string fileName,List<string[]> list)
    {
        var csvFile = Resources.Load(fileName) as TextAsset;
        using (var sr = new StringReader(csvFile.text))
        {
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                list.Add(line.Split(','));
            }
        }
    }
}
