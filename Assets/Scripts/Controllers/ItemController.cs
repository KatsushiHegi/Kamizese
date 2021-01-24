using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item item { get; private set; } = new Item();
    [SerializeField] Text PrefectureText;
    [SerializeField] Text NameText;
    [SerializeField] Text AttractivenessText;
    [SerializeField] Text PriceText;
    private void Start()
    {
        ItemPrefectureManager itemPrefectureManager = FindObjectOfType<ItemPrefectureManager>();
        GetComponent<Button>().onClick.AddListener(() => itemPrefectureManager.ItemClick(item));

        PrefectureText.text = item.targetPrefecture.prefectureName;
        NameText.text = item.name;
        PriceText.text = item.price.ToString("N0") + "千円";
        switch (item.attractiveness)
        {
            case 1:
                AttractivenessText.text = "★";
                AttractivenessText.color = new Color(1, 1, 1);
                break;
            case 2:
                AttractivenessText.text = "★★";
                AttractivenessText.color = new Color(255f/255f, 246f / 255f, 127f / 255f);
                break;
            case 3:
                AttractivenessText.text = "★★★";
                AttractivenessText.color = new Color(84f / 255f, 195f / 255f, 241f / 255f);
                break;
            case 4:
                AttractivenessText.text = "★★★★";
                AttractivenessText.color = new Color(186f / 255f, 121f / 255f, 177f / 255f);
                break;
            case 5:
                AttractivenessText.text = "★★★★★";
                AttractivenessText.color = new Color(105f / 255f, 189f / 255f, 131f / 255f);
                break;
        }
    }
}
