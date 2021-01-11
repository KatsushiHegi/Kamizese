using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefectureManager : MonoBehaviour
{
    public PlayerState playerState { get; private set; } = PlayerState.None;
    Item pickUpItem;
    Prefecture pickUpPrefecture;
    public void ItemClick(Item item)
    {
        pickUpItem = item;
        playerState = PlayerState.Item;
    }
    public void PrefectureClick(Prefecture prefecture)
    {
        if (playerState == PlayerState.Item)
        {
            prefecture.itemList.Add(pickUpItem);
            pickUpItem = null;
            playerState = PlayerState.None;
        }
        else if(playerState == PlayerState.None)
        {
            pickUpPrefecture = prefecture;
            playerState = PlayerState.Prefecture;
        }
    }
    public void ItemCancelClick()
    {
        if (playerState == PlayerState.Item)
        {
            pickUpItem = null;
            playerState = PlayerState.None;
        }
    }
    public void PrefectureCancelClick()
    {
        if (playerState == PlayerState.Prefecture)
        {
            pickUpPrefecture.itemList.Clear();
        }
    }
}

public enum PlayerState
{
    None,
    Item,
    Prefecture,
}