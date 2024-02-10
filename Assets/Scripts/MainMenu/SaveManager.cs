using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Save save;

    [Header("Player")]
    
    [SerializeField] private string playerName;
    [SerializeField] private Language language;
    private void Start()
    {
        save = new Save();

        bool verifySaveDir = VerifySaveDir();
        bool verifyPlayerSave = VerifyPlayerFile();
        if(!verifySaveDir)
        {
            save.CreateSaveDir();
        }

        Debug.Log(verifyPlayerSave);

        if (!verifyPlayerSave)
        {
            
            Debug.Log("Não existe");
            save.CreatePlayerFileSave();
        }
    }

    private bool VerifySaveDir()
    {
        string path = Application.persistentDataPath + "/Saves";
        return save.VerifySaveDir(path);
    }

    private bool VerifyPlayerFile()
    {
        string path = Application.persistentDataPath + "/Saves";
        return save.VerifySaveFile(path, "player", ".bits");
    }
}
