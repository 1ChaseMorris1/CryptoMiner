using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static List<bool> unlockedMaps = new List<bool>();

    public static void setItems(PlayerData data)
    {
        unlockedMaps = data.unlockedMaps;

        for (int i = 0; i < unlockedMaps.Count; i++)
            print(unlockedMaps[i]);
    }



}
