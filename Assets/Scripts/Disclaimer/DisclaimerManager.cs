using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerManager : MonoBehaviour
{
    [SerializeField] private float DisclaimerTimer;
    [SerializeField] private Scenes MainMenuScene;
    void Start()
    {
        Invoke("ChangeScene", DisclaimerTimer);
    }

    private void ChangeScene()
    {
        SceneManager.LoadSceneAsync(MainMenuScene.ToString());
        SceneManager.UnloadSceneAsync(Scenes.Disclaimer.ToString());
    }

}
