using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string initialLevelName;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private float audioVolume = 0.10f;

    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button exitButton;


    private void Awake()
    {
        audioSource.volume = audioVolume;
        audioSource.Play();

        playButton.onClick.AddListener(onClickPlayGame);
        playButton.onClick.AddListener(onClickExitGame);
    }

    private void onClickPlayGame()
   {
        SceneManager.LoadScene(initialLevelName);
        PauseMenu.StartGameFromMenu();
   }

    private void onClickExitGame()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }
}
