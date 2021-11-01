using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Inventory inventory = new Inventory(); 

    public static float bitcoinCost; 

    public List<bool> unlockedMaps = new List<bool>();

    public float money;

    public PlayerData(int x)
    {

        for (int i = 0; i < 5; i++)
            unlockedMaps.Add(false);

        unlockedMaps[0] = true;

        money = 500f;

        bitcoinCost = 1244f;

        inventory.cpus.Add(GameDriver.cpus[0]);

        inventory.psus.Add(GameDriver.psus[0]);

        inventory.rigs.Add(GameDriver.rigs[0]);
    }

    public PlayerData()
    {
        unlockedMaps = Player.unlockedMaps;

        money = Player.money;

        bitcoinCost = Player.bitcoinCost;

        inventory = Player.inventory;
    }


}
