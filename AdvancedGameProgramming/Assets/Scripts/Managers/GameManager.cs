using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    private bool isLoadingLevel = false;
    public bool IsLoadingLevel { get { return isLoadingLevel; } }

    public string currentLevelName;

    [SerializeField]
    private List<string> levelNames;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private GameObject playerInputManager;

    [SerializeField]
    private GameObject enemyManager;

    [SerializeField]
    private LoadingScreen loadingScreen;
    
    public List<string> LevelNames { get { return levelNames; } }

    public string levelToLoad;
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a repeated GameManager");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

    private void Start()
    {
        ExitLevel();
        StartLoadLevel(levelNames[0]);
    }

    public void StartLoadLevel(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    private IEnumerator LoadLevel(string sceneToLoad)
    {
        isLoadingLevel = true;

        loadingScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        // Unload current scene
        if (currentLevelName.Length != 0)
            SceneManager.UnloadSceneAsync(currentLevelName);

        // Load new scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            loadingScreen.UpdateSlider(asyncLoad.progress);
            yield return null;
        }
        loadingScreen.UpdateSlider(1);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));

        currentLevelName = sceneToLoad;

        // Initialize player etc.
        yield return new WaitForSeconds(1f);
        loadingScreen.gameObject.SetActive(false);
        isLoadingLevel = false;
    }

    public void InLevel()
    {
        player.SetActive(true);
        ui.SetActive(true);
        playerInputManager.SetActive(true);
        enemyManager.SetActive(true);
        ResetAll();
    }
    public void ExitLevel()
    {
        player.SetActive(false);
        ui.SetActive(false);
        playerInputManager.SetActive(false);
        enemyManager.SetActive(false);
    }

    public void ResetAll()
    {
        if (EnemySpawnManager._Instance.isActiveAndEnabled)
            EnemySpawnManager._Instance.ResetAllEnemies();
        if (ExpManager._Instance.isActiveAndEnabled)
            ExpManager._Instance.ResetAllOrbs();
    }

    public void LoadFromSave()
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    public void StartNewGame()
    {
        if (File.Exists(SaveGameManager._Instance.saveFilePath))
            File.Delete(SaveGameManager._Instance.saveFilePath);
        SaveGameManager._Instance.ResetPlayer();
    }
}
