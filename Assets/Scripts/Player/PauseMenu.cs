using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject OptionsMenu;

    [SerializeField]
    public static bool isPaused = false;

    public string mainMenuSceneName;

    void Start()
    {
        pauseMenu.SetActive(false);  
        OptionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }  
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OptionsButton()
    {
        OptionsMenu.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        pauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public static void StartGameFromMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
