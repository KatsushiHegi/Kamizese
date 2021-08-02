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
    [SerializeField] GameObject WarningSkip;
    /// <summary>
    /// コスト超過ポップを表示
    /// </summary>
    public void ActiveCostPop()
    {
        CostPop.SetActive(true);
    }
    /// <summary>
    /// ターンのリザルトポップを表示
    /// </summary>
    public void ActiveTurnResultPop()
    {
        TurnResultPop.SetActive(true);
    }
    /// <summary>
    /// リザルトのポップを表示
    /// </summary>
    public void ActiveResultPop()
    {
        ResultPop.SetActive(true);
    }
    /// <summary>
    /// ランキングのポップを表示
    /// </summary>
    public void ActiveRankingPop()
    {
        RankingPop.SetActive(true);
    }
    /// <summary>
    /// 警告ポップを表示
    /// </summary>
    public void ActiveWarningSkipPop()
    {
        WarningSkip.SetActive(true);
    }

    /// <summary>
    /// オブジェクトを非表示
    /// </summary>
    /// <param name="g">非表示にしたいオブジェクト</param>
    public void UnActive(GameObject g)
    {
        g.SetActive(false);
    }

}
