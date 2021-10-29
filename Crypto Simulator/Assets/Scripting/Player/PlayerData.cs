using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public List<bool> unlockedMaps = new List<bool>();

    public PlayerData(int x)
    {
        for (int i = 0; i < 5; i++)
            unlockedMaps.Add(false);

        unlockedMaps[0] = true;

    }

    public PlayerData()
    {
        unlockedMaps = Player.unlockedMaps; 
    }



}
