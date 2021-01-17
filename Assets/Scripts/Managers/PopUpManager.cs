using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] GameObject CostPop;

    public void ActiveCostPop()
    {
        CostPop.SetActive(true);
    }
    public void UnActive(GameObject g)
    {
        g.SetActive(false);
    }
}
