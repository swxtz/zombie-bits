using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Save save;
    private Load load;

    [Header("Player")]
    
    [SerializeField] private string playerName;
    [SerializeField] private Language language;
    private void Start()
    {
        save = new Save();
        load = new Load();


        bool verifySaveDir = VerifySaveDir();
        bool verifyPlayerSave = VerifyPlayerFile();
        if(!verifySaveDir)
        {
            save.CreateSaveDir();
        }

        if (!verifyPlayerSave)
        {
            PlayerSchema infos = new PlayerSchema {
                language = language,
                playerUsername = playerName
            };
            save.CreatePlayerFileSave(infos);
        }

        PlayerSchema playerInfo = load.LoadPlayerSave();
        Debug.Log(playerInfo.language);

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
