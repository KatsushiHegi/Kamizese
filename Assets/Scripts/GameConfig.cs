using System;
using System.Collections.Generic;

[Serializable]
public class GameConfig 
{
    public List<int> scoreList = new List<int>();
    public GameConfig()
    {
        for (int i = 0; i < 3; i++)
        {
            scoreList.Add(0);
        }
    }

}
