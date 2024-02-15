using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenuUI : MonoBehaviour
{
    private Scenes Scenes;
    private VisualElement RootCompoment;

    private void Start()
    {
        RootCompoment = GetComponent<UIDocument>().rootVisualElement;
        Scenes = new Scenes();
        var playerAs = RootCompoment.Q<Label>("PlayerWith");

        playerAs.text = "Jogando como: " + Environment.UserName;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        var buttonStart = root.Q<Button>("ButtonStart");
        var buttonExit = root.Q<Button>("ButtonExit");
        var playerAs = root.Q<Label>("PlayerWith");

        buttonStart.clicked += () => StartGame();
        buttonExit.clicked += () => ExitGame();
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync("Scenes/Limbo");
        SceneManager.UnloadSceneAsync("Scenes/Menu");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
