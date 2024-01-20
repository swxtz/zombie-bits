using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string initialLevelName;

    [SerializeField]
    private AudioSource audioSource;
    private float audioVolume = 0.10f;


    private void Awake()
    {
        vSyncManager syncManager = new vSyncManager();
        syncManager.ChangeVSyncMode(vSyncManager.vSyncMode.On);

        Debug.Log("VSync: " + QualitySettings.vSyncCount);

        audioSource.volume = audioVolume;
        audioSource.Play();
    }

    public void PlayGame()
   {
        SceneManager.LoadScene(initialLevelName);
        PauseMenu.StartGameFromMenu();
   }

    public void ExitGame()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }
}
