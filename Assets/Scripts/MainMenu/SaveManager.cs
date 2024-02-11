using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Save save;
    private Load load;

    private string saveName = "player";
    private string optionsName = "options";

    [Header("Player")] 
    [SerializeField] private string playerName;
    [SerializeField] private Language language;


    [Header("Options")]
    [SerializeField] private float mainMenuMusicVolume;
    [SerializeField] private bool mainMenuMusicMuted;
    private void Start()
    {
        save = new Save();
        load = new Load();


        bool verifySaveDir = VerifySaveDir();
        bool verifyPlayerSave = VerifyPlayerFile();
        bool verifyOptionFile = VerifyOptionsFile();

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

        if(!verifyOptionFile)
        {

            OptionsSchema infos = new OptionsSchema
            {
                mainMenuMusicVolume = mainMenuMusicVolume,
                mainMenuMusicMuted = mainMenuMusicMuted,
                xSensi = 100f,
                ySensi = 100f,
            };

            save.CreateOptionsFile(infos);
        }

        PlayerSchema playerInfo = load.LoadPlayerSave();
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

    private bool VerifyOptionsFile()
    {
        string path = Application.persistentDataPath + "/Saves";
        return save.VerifySaveFile(path, "options", ".bits");
    }
}
