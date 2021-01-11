using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] ItemPrefectureManager ItemPrefectureManager;
    public Item item { get; private set; } = new Item();
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ItemPrefectureManager.ItemClick(item);
        });
    }
    public void SetItem(Prefecture targetPrefecture, string name, string description)
    {
        item.targetPrefecture = targetPrefecture;
        item.name = name;
        item.description = description;
    }
    
}
