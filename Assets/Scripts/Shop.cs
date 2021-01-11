using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] GameObject itemPref;
    [SerializeField] Transform parent;
    CSVReader CSVReader;
    private void Awake()
    {
        CSVReader = new CSVReader();
        CSVReader.Init();
    }
    private void Start()
    {
        SetShop();
    }
    public void SetShop()
    {
        for (int i = 0; i < CSVReader.csvData.Count; i++)
        {
            var ins = Instantiate(itemPref, parent);
            
            ins.GetComponent<ItemController>().SetItem(
                PrefectureManager.GetPrefecture(int.Parse(CSVReader.csvData[i][0])),
                CSVReader.csvData[i][1],
                CSVReader.csvData[i][2]
                );
            
        }
    }

}
