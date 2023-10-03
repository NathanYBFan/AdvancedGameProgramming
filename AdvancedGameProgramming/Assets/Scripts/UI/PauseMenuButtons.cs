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
        if (!IsSettingsMenuOpened())
        {
            SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
        else
        {
            SceneManager.UnloadSceneAsync("SettingsMenu");
            Time.timeScale = 0f;
        }
    }

    private bool IsSettingsMenuOpened()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == "SettingsMenu" && scene.isLoaded)
                return true;
        }
        return false;
    }

    public bool IsGamePaused() // Returns if it is paused
    {
        if (Time.timeScale == 0)
            return true;
        else
            return false;
    }
}
