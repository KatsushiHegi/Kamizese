using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefectureController : MonoBehaviour
{
    [SerializeField] ItemPrefectureManager ItemPrefectureManager;
    public Prefecture prefecture { get; private set; } = new Prefecture();
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ItemPrefectureManager.PrefectureClick(prefecture);
        });
    }

}
