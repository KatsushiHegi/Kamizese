using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item item { get; private set; } = new Item();
    private void Start()
    {
        ItemPrefectureManager itemPrefectureManager = FindObjectOfType<ItemPrefectureManager>();
        GetComponent<Button>().onClick.AddListener(() => {
            itemPrefectureManager.ItemClick(item);
        });
        transform.GetChild(0).GetComponent<Text>().text =
            item.targetPrefecture.prefectureName + "　" +
            item.name +
            "　魅力：" + item.attractiveness +
            "　" + item.price.ToString("N0") + "千円";

        GetComponent<Image>().color =
            item.attractiveness == 1 ? new Color(1,1,1) :
            item.attractiveness == 2 ? new Color(0.5f,1,0.5f) :
            item.attractiveness == 3 ? new Color(0.5f,0.6f,1) :
            item.attractiveness == 4 ? new Color(1,1,0.5f) :
            Color.red;

    }
    public void SetItem(Prefecture targetPrefecture, string name, string description)
    {
        item.targetPrefecture = targetPrefecture;
        item.name = name;
        item.description = description;
    }
    
}
