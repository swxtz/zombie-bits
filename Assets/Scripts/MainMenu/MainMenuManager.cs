using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string initialLevelName;
    //[SerializeField]
    //public Scene initialLevelScene;

    public void PlayGame()
   {
        SceneManager.LoadScene(initialLevelName);
   }

    public void ExitGame()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }
}
