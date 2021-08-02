using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemDispController : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text DescriptionText;
    /// <summary>
    /// Item選択画面を用意します
    /// </summary>
    public void Set(Item item)
    {
        NameText.text = item.name;
        DescriptionText.text = item.description;
    }

}
