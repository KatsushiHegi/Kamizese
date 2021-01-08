using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text TurnValueText;
    [SerializeField] Text MoneyValueText;
    private void Start()
    {

    }

    public void SetTurnText(int value)
    {
        TurnValueText.text = value.ToString();
    }
    public void SetMoneyText(int value)
    {
        MoneyValueText.text = value.ToString();
    }
}
