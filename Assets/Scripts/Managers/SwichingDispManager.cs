﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichingDispManager : MonoBehaviour
{
    [SerializeField] GameObject NihonDisp;
    [SerializeField] GameObject EnlargedDisp;
    [SerializeField] Button[] Buttons = new Button[8];
    [SerializeField] GameObject[] RegionDisps = new GameObject[8];
    [SerializeField] ConfirmPopUpManager ConfirmPopUpManager;
    GameObject currentDisp;
    private void Start()
    {
        Buttons[0].onClick.AddListener(() => ToArea(RegionDisps[0]));
        Buttons[1].onClick.AddListener(() => ToArea(RegionDisps[1]));
        Buttons[2].onClick.AddListener(() => ToArea(RegionDisps[2]));
        Buttons[3].onClick.AddListener(() => ToArea(RegionDisps[3]));
        Buttons[4].onClick.AddListener(() => ToArea(RegionDisps[4]));
        Buttons[5].onClick.AddListener(() => ToArea(RegionDisps[5]));
        Buttons[6].onClick.AddListener(() => ToArea(RegionDisps[6]));
        Buttons[7].onClick.AddListener(() => ToArea(RegionDisps[7]));
    }
    public void ToNihonDisp()
    {
        currentDisp.SetActive(false);
        EnlargedDisp.SetActive(false);
        NihonDisp.SetActive(true);
        ConfirmPopUpManager.Set();
    }
    void ToArea(GameObject areaDisp)
    {
        NihonDisp.SetActive(false);
        EnlargedDisp.SetActive(true);
        areaDisp.SetActive(true);
        currentDisp = areaDisp;
    }
}
