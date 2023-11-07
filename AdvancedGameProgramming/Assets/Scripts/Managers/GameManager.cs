using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager _Instance;

    private bool isLoadingLevel = false;
    public bool IsLoadingLevel { get { return isLoadingLevel; } }

    private string currentLevelName;

    [SerializeField]
    private List<string> levelNames;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Destroyed a repeated GameManager");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

    private void Start()
    {
        StartCoroutine(LoadLevel(levelNames[0]));
    }

    private IEnumerator LoadLevel(string sceneToLoad)
    {
        isLoadingLevel = true;
        
        // Unload current scene
        
        // Load new scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;

        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));

        currentLevelName = sceneToLoad;


        // Initialize player etc.

        isLoadingLevel = false;
    }
}
