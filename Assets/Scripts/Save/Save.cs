using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save : MonoBehaviour
{
    public string basePath = Application.persistentDataPath;
    private string saveName = "default";
    public SaveSchema saveSchema;

    public void CreateSave()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = basePath + "/Saves"; //AppData/LocalLow

        FileStream saveFile = File.Create(path + saveName + ".bits");
        formatter.Serialize(saveFile, saveSchema);
        saveFile.Close();

        print("Game Saved");
    }

}
