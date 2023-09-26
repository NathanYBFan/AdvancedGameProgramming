using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{

    public void ResumeButtonPressed()
    {
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

    }
}
