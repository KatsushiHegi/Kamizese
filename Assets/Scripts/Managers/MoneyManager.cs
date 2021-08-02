using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    const int Initial = 2000;//初期金額
    public int money { get; private set; } = Initial;
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] ResultManager ResultManager;
    [SerializeField] Text MoneyText;
    [SerializeField] Text CostText;
    int cost = 0;

    /// <summary>
    /// 所持金テキストを表示します
    /// </summary>
    public void SetMoneyText()
    {
        MoneyText.text = money.ToString("N0") + "千円";
        SetCostBalanceText();
    }
    /// <summary>
    /// コストテキストを表示します
    /// </summary>
    public void SetCostBalanceText()
    {
        CalcCost();
        CostText.text = cost.ToString("N0") + "千円";
        int balance = money - cost;
        if (balance < 0) CostText.color = Color.red;
        else CostText.color = Color.black;
    }
    void CalcCost()
    {
        int sum = 0;
        foreach (PrefectureController pc in PrefectureManager.prefectureControllers)
        {
            foreach (Item i in pc.prefecture.itemList)
            {
                sum += i.price;
            }
        }
        cost = sum;
    }
    /// <summary>
    /// コストと所持金の清算処理をします
    /// </summary>
    /// <returns>完了できたらTRUEを返します</returns>
    public bool Liquidation()
    {
        if (cost > money) return false;
        money -= cost;
        ResultManager.sumCost += cost;
        return true;
    }
    /// <summary>
    /// 報酬金額を計算します
    /// </summary>
    /// <param name="people">移動人数</param>
    /// <param name="distance">移動距離</param>
    /// <returns>報酬金額を返します</returns>
    public int GetRewarded(int people, float distance)
    {
        double standard = people * 0.005;
        double multiply = distance;
        int reward = (int)(standard * multiply);
        money += reward;
        return reward;
    }
}
