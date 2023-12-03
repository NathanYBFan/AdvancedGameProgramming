using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuObject;

    [SerializeField]
    private GameObject LoadSelectObject;

    [SerializeField]
    private GameObject LoadGameButton;

    public void OnEnable()
    {
        CheckSaveGamePresent();
    }

    public void PlayButtonPressed(string nameOfSceneToLoad)
    {
        SwitchBetweenMenus(false);
    }

    public void BackButtonPressed()
    {
        SwitchBetweenMenus(true);
    }

    public void SettingsButtonPressed(string nameOfSceneToLoad)
    {
        SceneManager.LoadScene(nameOfSceneToLoad, LoadSceneMode.Additive);
    }

    public void QuitButtonPressed()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void NewGamePressed()
    {
        GameManager._Instance.StartLoadLevel(GameManager._Instance.LevelNames[1]);
        // Reset player stats
        GameManager._Instance.StartNewGame();
        SaveGameManager._Instance.saveGamePresent = false;
    }

    public void LoadGamePressed()
    {
        SaveGameManager._Instance.LoadGame();
        GameManager._Instance.LoadFromSave();
    }

    private void SwitchBetweenMenus(bool mainMenuActive)
    {
        MainMenuObject.SetActive(mainMenuActive);
        LoadSelectObject.SetActive(!mainMenuActive);
    }

    private void CheckSaveGamePresent()
    {
        LoadGameButton.GetComponent<Button>().interactable = SaveGameManager._Instance.saveGamePresent;
    }

}
