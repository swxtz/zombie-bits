using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string initialLevelName;

    [SerializeField] private AudioSource audioSource;
    public float audioVolume = 0.10f;

    [Header("Menu Wrappers")]
    [SerializeField] private GameObject mainMenuWrapper;
    [SerializeField] private GameObject optionsWrapper;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    [Header("Options Buttons")]
    [SerializeField] private Button backToMainMenu;
    [SerializeField] private GameObject volumeSlider;


    private void Awake()
    {
        audioSource.Play();

        playButton.onClick.AddListener(OnClickPlayGame);
        exitButton.onClick.AddListener(OnClickExitGame);
        optionsButton.onClick.AddListener(OnClickOptionsButton);
        backToMainMenu.onClick.AddListener(OnClickBackToMainMenu);

        
    }

    private void Update()
    {
        audioSource.volume = audioVolume;
    }

    private void OnClickPlayGame()
   {
        SceneManager.LoadSceneAsync(initialLevelName);
        PauseMenu.StartGameFromMenu();
   }

    private void OnClickExitGame()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }

    private void OnClickOptionsButton()
    {
        Debug.Log("Opções");
        optionsWrapper.SetActive(true);
        mainMenuWrapper.SetActive(false);
    }

    private void OnClickBackToMainMenu()
    {
        mainMenuWrapper.SetActive(true);
        optionsWrapper.SetActive(false);
    }

    
}
