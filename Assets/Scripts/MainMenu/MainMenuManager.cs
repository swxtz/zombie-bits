using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string initialLevelName;

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

    [Header("Player Infos")]
    [SerializeField] private TMPro.TextMeshProUGUI loggedInAs;

    private Load load;

    private void Start()
    {
        load = new Load();

        var playerInfos = load.LoadPlayerSave();

        loggedInAs.text = "Jogando como: " + playerInfos.playerUsername;
    }

    private void Awake()
    {
        playButton.onClick.AddListener(OnClickPlayGame);
        exitButton.onClick.AddListener(OnClickExitGame);
        optionsButton.onClick.AddListener(OnClickOptionsButton);
        backToMainMenu.onClick.AddListener(OnClickBackToMainMenu);

        Time.timeScale = 1f;



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
