using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader
{
    public List<string[]> csvData { get; private set; } = new List<string[]>();
    public void Init()
    {
        var csvFile = Resources.Load("ItemInfo") as TextAsset;
        using (var sr = new StringReader(csvFile.text))
        {
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                csvData.Add(line.Split(','));
            }
        }
        /*Debug*/
        csvData.ForEach(x =>
        {
            foreach (var item in x)
            {
                Debug.Log(item);
            }
        });
    }
}
