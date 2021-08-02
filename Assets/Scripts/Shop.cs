using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] GameObject itemPref;
    [SerializeField] Transform parent;
    
    private void Start()
    {
        SetShop();
    }
    /// <summary>
    /// ショップを用意します
    /// </summary>
    public void SetShop()
    {
        CSVReader CSVReader = new CSVReader();
        CSVReader.SetItemInfo();
        for (int i = 0; i < CSVReader.itemCsvData.Count; i++)
        {
            var ins = Instantiate(itemPref, parent);
            
            ins.GetComponent<ItemController>().item.Set(
                PrefectureManager.GetPrefecture(int.Parse(CSVReader.itemCsvData[i][0])),
                CSVReader.itemCsvData[i][1],
                CSVReader.itemCsvData[i][2],
                Random.Range(1,6)
                );

            
        }
    }

}
