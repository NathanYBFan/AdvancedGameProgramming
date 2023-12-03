using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class SettingsMenu : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Name of settings menu scene name")]
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

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("")]
    private VideoSettings videoSettings;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Controls display button")]
    private AudioSettings audioSettings;

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
        LoadSettings();
    }

    public void UnloadScene()
    {
        SaveSettings();
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
    public void SaveSettings()
    {
        // Create binary formatter
        BinaryFormatter bf = new BinaryFormatter();

        // File to create
        FileStream file = File.Create(SaveGameManager._Instance.settingsFilePath);

        bf.Serialize(file, PackageSettingsData());
        file.Close();
    }

    public void LoadSettings()
    {
        if (!File.Exists(SaveGameManager._Instance.settingsFilePath)) return;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(SaveGameManager._Instance.settingsFilePath, FileMode.Open);
        SettingsSaveData data = (SettingsSaveData) bf.Deserialize(file);

        file.Close();

        UnpackageSettingsData(data);
    }

    private SettingsSaveData PackageSettingsData()
    {
        SettingsSaveData settingsData = new SettingsSaveData();
        settingsData.windowState = videoSettings.savedWindowState;
        settingsData.resolutionState = videoSettings.savedResolutionState;
        settingsData.fpsCap = videoSettings.savedFpsCap;
        settingsData.vSyncOn = videoSettings.savedVSyncState;

        settingsData.masterVolume = audioSettings.masterVolume;
        settingsData.musicVolume = audioSettings.musicVolume;
        settingsData.playerVolume = audioSettings.playerVolume;
        settingsData.enemyVolume = audioSettings.enemyVolume;

        return settingsData;
    }

    private void UnpackageSettingsData(SettingsSaveData data)
    {
        videoSettings.savedWindowState = data.windowState;
        videoSettings.savedResolutionState = data.resolutionState;
        videoSettings.savedFpsCap = data.fpsCap;
        videoSettings.savedVSyncState = data.vSyncOn;

        audioSettings.masterVolume = data.masterVolume;
        audioSettings.musicVolume = data.musicVolume;
        audioSettings.playerVolume = data.playerVolume;
        audioSettings.enemyVolume = data.enemyVolume;
    }
}

[Serializable]
class SettingsSaveData
{
    public int windowState { get; set; }
    public int resolutionState { get; set; }
    public int fpsCap { get; set; }
    public bool vSyncOn { get; set; }
    public float masterVolume { get; set; }
    public float musicVolume { get; set; }
    public float playerVolume { get; set; }
    public float enemyVolume { get; set; }
}