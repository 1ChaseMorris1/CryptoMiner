using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInfo : MonoBehaviour
{

    // save and load the player class. 

    public static void savePlayer()
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/4.Keokee";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData player = new PlayerData();

        formatter.Serialize(stream, player);

        stream.Close();
    }

    public static void loadPlayer()
    {
        string path = Application.persistentDataPath + "/4.Keokee";

        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            Player.setItems(data);

        } else
        {
            PlayerData data = new PlayerData(1);

            Player.setItems(data);
        }
    }

}
