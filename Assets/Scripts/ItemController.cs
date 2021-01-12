using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] Text nameText;
    public Item item { get; private set; } = new Item();
    private void Start()
    {
        ItemPrefectureManager itemPrefectureManager = FindObjectOfType<ItemPrefectureManager>();
        GetComponent<Button>().onClick.AddListener(() => {
            itemPrefectureManager.ItemClick(item);
        });
        nameText.text = item.name;
    }
    public void SetItem(Prefecture targetPrefecture, string name, string description)
    {
        item.targetPrefecture = targetPrefecture;
        item.name = name;
        item.description = description;
    }
    
}
