using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Scene pauseMenuScene;

    private void Start()
    {
        Time.timeScale = 1f;
        CheckForPauseMenu();
    }

    public void OpenPauseMenu()
    {
        CheckForPauseMenu();
        if (!pauseMenuScene.isLoaded)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync(pauseMenuScene);
        }
    }

    public void LoadAdditiveScene(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Additive);
    }

    public void LoadSingleScene(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Single);
    }

    private void CheckForPauseMenu()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Scene scene = SceneManager.GetSceneByBuildIndex(i);
            if (scene.name == "PauseMenu")
                pauseMenuScene = scene;
        }
    }
}
