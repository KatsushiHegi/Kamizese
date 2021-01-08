using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichingDispManager : MonoBehaviour
{
    [SerializeField] GameObject NihonDisp;
    [SerializeField] GameObject KantoDisp;
    [SerializeField] Button KantoButton;
    private void Start()
    {
        KantoButton.onClick.AddListener(() => ToArea(KantoDisp));
    }
    void ToArea(GameObject AreaDisp)
    {
        NihonDisp.SetActive(false);
        AreaDisp.SetActive(true);
    }
}
