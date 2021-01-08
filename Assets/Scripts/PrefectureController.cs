using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefectureController : MonoBehaviour
{
    public Prefecture prefecture { get; private set; }
    private void Start()
    {
        prefecture = new Prefecture();
        GetComponent<Button>().onClick.AddListener(() => { });
    }

}
