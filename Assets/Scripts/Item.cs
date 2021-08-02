using UnityEngine;

public class Item
{
    public string name;  //名前
    public string description;  //説明
    public int price;  //値段
    public int attractiveness;  //魅力
    public Prefecture targetPrefecture; //対象都道府県

    /// <summary>
    /// Itemクラスの初期化を実行します
    /// </summary>
    /// <param name="targetPrefecture">ターゲットの都道府県</param>
    /// <param name="name">Itemの名前</param>
    /// <param name="description">Itemの説明</param>
    /// <param name="attractiveness">Itemの魅力度</param>
    public void Set(Prefecture targetPrefecture, string name, string description, int attractiveness)
    {
        this.targetPrefecture = targetPrefecture;
        this.name = name;
        this.description = description;
        this.attractiveness = attractiveness;
        price = 1000 * attractiveness + Random.Range(-500, 500);
    }
}
