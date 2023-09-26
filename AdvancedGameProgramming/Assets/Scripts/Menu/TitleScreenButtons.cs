using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPressed(string nameOfSceneToLoad)
    {
        Debug.Log(nameOfSceneToLoad);
        SceneManager.LoadScene(nameOfSceneToLoad, LoadSceneMode.Single);
    }

    public void SettingsButtonPressed(string nameOfSceneToLoad)
    {
        SceneManager.LoadScene(nameOfSceneToLoad, LoadSceneMode.Additive);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

}
