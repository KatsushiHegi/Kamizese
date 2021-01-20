using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUpManager : MonoBehaviour
{
    [SerializeField] GameObject CostPop;
    [SerializeField] GameObject TurnResultPop;
    [SerializeField] GameObject ResultPop;
    [SerializeField] GameObject RankingPop;
    public void ActiveCostPop()
    {
        CostPop.SetActive(true);
    }
    public void ActiveTurnResultPop()
    {
        TurnResultPop.SetActive(true);
    }
    public void ActiveResultPop()
    {
        ResultPop.SetActive(true);
    }
    public void ActiveRankingPop()
    {
        RankingPop.SetActive(true);
    }
    public void UnActive(GameObject g)
    {
        g.SetActive(false);
    }
    public void ToTitle() => SceneManager.LoadScene("Title");
}
