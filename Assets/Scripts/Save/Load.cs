using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load 
{
    public string basePath = Application.persistentDataPath;

    // File Names
    private string saveName = "player";
    private string optionsName = "options";

    public PlayerSchema LoadPlayerSave()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves"; //AppData/LocalLow
        FileStream saveFile = File.Open(path + "/" + saveName + ".bits", FileMode.Open);

        PlayerSchema infos = (PlayerSchema)formatter.Deserialize(saveFile);
        saveFile.Close();

        return infos;
    }

    public OptionsSchema LoadOptions()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves"; //AppData/LocalLow
        FileStream saveFile = File.Open(path + "/" + optionsName + ".bits", FileMode.Open);

        OptionsSchema infos = (OptionsSchema)formatter.Deserialize(saveFile);
        saveFile.Close();

        return infos;
    }
}
