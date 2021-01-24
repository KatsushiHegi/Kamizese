using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    const int Initial = 2000;//初期金額
    public int money { get; private set; } = Initial;
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] Text MoneyText;
    [SerializeField] Text CostText;
    int cost = 0;

    public void SetMoneyText()
    {
        MoneyText.text = money.ToString("N0") + "千円";
        SetCostBalanceText();
    }
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
    public bool Liquidation()
    {
        if (cost > money) return false;
        money -= cost;
        return true;
    }
    public int GetRewarded(int people, float distance)
    {
        double standard = people * 0.1;
        double multiply = distance - 1.5;
        int reward = (int)(standard * multiply);
        money += reward;
        return reward;
    }
}
