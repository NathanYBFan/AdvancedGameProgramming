using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("Name of settings menu scene name")]
    private string settingsMenuSceneName;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Video Controls settings display object")]
    private GameObject videoControls;

    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("Video display button")] 
    private Image videoButton;

    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("Audio Controls settings display object")]
    private GameObject audioControls;

    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("Audio display button")] 
    private Image audioButton;

    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("Controls settings display object")] 
    private GameObject inGameControls;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Controls display button")]
    private Image controlsButton;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Original selected button color")]
    private Color selectedButtonColor;

    [Foldout("Specs")]
    [SerializeField][Tooltip("Original deselected button color")] 
    private Color deselectedButtonColor;

    // Start is called before the first frame update
    void Awake()
    {
        videoButton.color = selectedButtonColor;
        audioButton.color = deselectedButtonColor;
        controlsButton.color = deselectedButtonColor;
        videoControls.SetActive(true);
        audioControls.SetActive(false);
        inGameControls.SetActive(false);
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(settingsMenuSceneName);
    }

    public void SettingsButtonPressed(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1: // Video settings
                videoButton.color = selectedButtonColor;
                audioButton.color = deselectedButtonColor;
                controlsButton.color = deselectedButtonColor;
                videoControls.SetActive(true);
                audioControls.SetActive(false);
                inGameControls.SetActive(false);
                break;
            case 2: // Audio settings
                videoButton.color = deselectedButtonColor;
                audioButton.color = selectedButtonColor;
                controlsButton.color = deselectedButtonColor;
                videoControls.SetActive(false);
                audioControls.SetActive(true);
                inGameControls.SetActive(false);
                break;
            case 3: // Control settings
                videoButton.color = deselectedButtonColor;
                audioButton.color = deselectedButtonColor;
                controlsButton.color = selectedButtonColor;
                videoControls.SetActive(false);
                audioControls.SetActive(false);
                inGameControls.SetActive(true);
                break;
            default: // Error
                Debug.Log("Invalid button selected");
                break;
        }
    }
}
