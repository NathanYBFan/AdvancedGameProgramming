using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("")]
    private GameObject upgradeMenu;

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

    public bool IsSettingsMenuOpened()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == "SettingsMenu" && scene.isLoaded)
                return true;
        }
        return false;
    }

    public bool IsUpgradeMenuOpened()
    {
        return upgradeMenu.activeInHierarchy;
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
