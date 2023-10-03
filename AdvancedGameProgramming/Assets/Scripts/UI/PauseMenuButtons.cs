using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{

    public void ResumeButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void SettingsButtonPressed()
    {
        OpenSettingsMenu();
    }

    public void ToMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        if (!IsGamePaused())
        {
            SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
            Time.timeScale = 1.0f;
        }
        else
        {
            SceneManager.UnloadSceneAsync("SettingsMenu");
            Time.timeScale = 0f;
        }
    }

    public bool IsGamePaused() // Returns if it is paused
    {
        if (Time.timeScale == 0)
            return true;
        else
            return false;
    }
}
