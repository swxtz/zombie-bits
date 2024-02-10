using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load 
{
    public string basePath = Application.persistentDataPath;

    public PlayerSchema LoadPlayerSave()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves"; //AppData/LocalLow
        FileStream saveFile = File.Open(path + "/" + "player" + ".bits", FileMode.Open);

        PlayerSchema infos = (PlayerSchema)formatter.Deserialize(saveFile);
        saveFile.Close();

        return infos;
    }
}
