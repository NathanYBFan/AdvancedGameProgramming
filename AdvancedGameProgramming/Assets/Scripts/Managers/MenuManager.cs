using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Scene pauseMenuScene;

    private void Start()
    {
        CheckForPauseMenu();
    }

    public void OpenPauseMenu()
    {
        CheckForPauseMenu();
        if (!pauseMenuScene.isLoaded)
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync(pauseMenuScene);
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
