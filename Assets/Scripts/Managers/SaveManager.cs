using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameConfig GameConfig { get; private set; }
    /// <summary>
    /// セーブデータをローカルからロードします
    /// </summary>
    public void LoadDataFromLocal()
    {
        string json = PlayerPrefs.GetString("gameconfig", null);
        GameConfig = String.IsNullOrEmpty(json) ? new GameConfig() : JsonUtility.FromJson<GameConfig>(json);
    }

    /// <summary>
    /// セーブデータをローカルへセーブします
    /// </summary>
    public void SaveDataToLocal()
    {
        var json = JsonUtility.ToJson(GameConfig);
        PlayerPrefs.SetString("gameconfig", json);
    }
}
