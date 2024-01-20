using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string initialLevelName;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float audioVolume = 0.10f;

    [Header("Menu Wrappers")]
    [SerializeField] private GameObject mainMenuWrapper;
    [SerializeField] private GameObject optionsWrapper;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    

    private void Awake()
    {
        audioSource.volume = audioVolume;
        audioSource.Play();

        playButton.onClick.AddListener(onClickPlayGame);
        exitButton.onClick.AddListener(onClickExitGame);
        optionsButton.onClick.AddListener(onClickOptionsButton);

    }

    private void onClickPlayGame()
   {
        SceneManager.LoadSceneAsync(initialLevelName);
        PauseMenu.StartGameFromMenu();
   }

    private void onClickExitGame()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }

    private void onClickOptionsButton()
    {
        Debug.Log("Opções");
    }
}
