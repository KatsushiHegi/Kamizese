using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefectureManager : MonoBehaviour
{
    [SerializeField] SelectItemDispController SelectItemDispController;
    [SerializeField] PrefectureSelectController PrefectureSelectController;
    public PlayerState playerState { get; private set; } = PlayerState.None;
    Item pickUpItem;
    Prefecture pickUpPrefecture;
    /// <summary>
    /// Itemをクリックしたときの処理を実行します
    /// </summary>
    public void ItemClick(Item item)
    {
        pickUpItem = item;
        playerState = PlayerState.Item;
        SelectItemDispController.gameObject.SetActive(true);
        SelectItemDispController.Set(pickUpItem);
        DebugLog();
    }
    /// <summary>
    /// 都道府県をクリックしたときの処理を実行します
    /// </summary>
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
        else if (playerState == PlayerState.None)
        {
            pickUpPrefecture = prefecture;
            playerState = PlayerState.Prefecture;
            DebugLog();
        }
        else {
            pickUpPrefecture = prefecture;
            DebugLog();
        }
        PrefectureSelectController.SetSelectedPrefectureText(pickUpPrefecture?.prefectureName);
    }
    /// <summary>
    /// Itemキャンセルをクリックしたときの処理を実行します
    /// </summary>
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
    /// <summary>
    /// 都道府県キャンセルをクリックしたときの処理を実行します
    /// </summary>
    public void PrefectureCancelClick()
    {
        if (playerState == PlayerState.Prefecture)
        {
            pickUpPrefecture.itemList.Clear();
            playerState = PlayerState.None;
            DebugLog();
            PrefectureSelectController.SetSelectedPrefectureText("削除完了");
        }
        else
        {
            PrefectureSelectController.SetSelectedPrefectureText("未選択");
        }
    }
    /// <summary>
    /// 選択中の都道府県をリセットします
    /// </summary>
    public void ResetPickUpPrefecture()
    {
        pickUpPrefecture = null;
        PrefectureSelectController.SetSelectedPrefectureText("");
    }
    void DebugLog()
    {
        Debug.Log(playerState);
    }
}

/// <summary>
/// プレイヤーの現在の状態
/// </summary>
public enum PlayerState
{
    None,
    Item,
    Prefecture,
}