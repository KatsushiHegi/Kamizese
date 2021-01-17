using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefectureManager : MonoBehaviour
{
    [SerializeField] SelectItemDispController SelectItemDispController;
    public PlayerState playerState { get; private set; } = PlayerState.None;
    Item pickUpItem;
    Prefecture pickUpPrefecture;
    public void ItemClick(Item item)
    {
        pickUpItem = item;
        playerState = PlayerState.Item;
        SelectItemDispController.gameObject.SetActive(true);
        SelectItemDispController.Set(pickUpItem);
        DebugLog();
    }
    public void PrefectureClick(Prefecture prefecture)
    {
        if (playerState == PlayerState.Item)
        {
            prefecture.itemList.Add(pickUpItem);
            pickUpItem = null;
            playerState = PlayerState.None;
            SelectItemDispController.gameObject.SetActive(false);
            DebugLog();
        }
        else if(playerState == PlayerState.None)
        {
            pickUpPrefecture = prefecture;
            playerState = PlayerState.Prefecture;
            DebugLog();
        }
    }
    public void ItemCancelClick()
    {
        if (playerState == PlayerState.Item)
        {
            pickUpItem = null;
            playerState = PlayerState.None;
            SelectItemDispController.gameObject.SetActive(false);
            DebugLog();
        }
    }
    public void PrefectureCancelClick()
    {
        if (playerState == PlayerState.Prefecture)
        {
            pickUpPrefecture.itemList.Clear();
            playerState = PlayerState.None;
            DebugLog();
        }
    }
    void DebugLog()
    {
        Debug.Log(playerState);
    }
}

public enum PlayerState
{
    None,
    Item,
    Prefecture,
}