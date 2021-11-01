using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Inventory inventory;

    public static float bitcoinCost; 

    public static List<bool> unlockedMaps = new List<bool>();

    public static float money; 

    public static void setItems(PlayerData data)
    {

        unlockedMaps = data.unlockedMaps;

        money = data.money;

        inventory = data.inventory;

    
    }



}
