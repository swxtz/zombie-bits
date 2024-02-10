using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save
{
    public string basePath = Application.persistentDataPath;
    public PlayerSchema savePlayerSchema;

    // File Names
    private string saveName = "player";
    private string optionsName = "options";

    public void CreateSaveDir()
    {

        string path = basePath + "/Saves";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public void CreatePlayerFileSave(PlayerSchema infos)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves"; //AppData/LocalLow

        Directory.CreateDirectory(path + "/");
        FileStream saveFile = File.Create(path + "/" + saveName + ".bits");
        formatter.Serialize(saveFile, infos);
        saveFile.Close();

    }

    public void CreateOptionsFile(OptionsSchema infos)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves";

        Directory.CreateDirectory(path + "/");
        FileStream saveFile = File.Create(path + "/" + optionsName + ".bits");
        formatter.Serialize(saveFile, infos);
        saveFile.Close();
    }

    public bool VerifySaveDir(string dir)
    {
        if (File.Exists(dir))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool VerifySaveFile(string dir, string name, string fileExt)
    {
        if(File.Exists(dir + "/" + name + fileExt)) {
            return true;
        } else
        {
            return false;
        }
    }

}