using UnityEngine;
using TMPro;
using NaughtyAttributes;
public class VideoSettings : MonoBehaviour
{
    [Header("FPS Initializations")]
    [SerializeField, Required] private TMP_InputField fpsCap;
    [Header("Vsync Initializations")]
    [SerializeField, Required] private GameObject VSyncCheckmark;

    public int savedWindowState;
    public int savedResolutionState;
    public int savedFpsCap;
    public bool savedVSyncState;

    // Start is called before the first frame update
    private void OnEnable()
    {
        WindowStateChanged(savedWindowState);
        ResolutionChanged(savedResolutionState);
        fpsCap.text = savedFpsCap.ToString();
        VSyncCheckmark.SetActive(savedVSyncState);
    }

    public void WindowStateChanged(int value)
    {
        Screen.fullScreenMode = value switch
        {
            0 => // Borderless
                FullScreenMode.FullScreenWindow,
            1 => // Windowed
                FullScreenMode.Windowed,
            2 => // Fullscreen
                FullScreenMode.ExclusiveFullScreen,
            _ => Screen.fullScreenMode
        };
        savedWindowState = value;
    }

    public void ResolutionChanged(int value)
    {
        // We need to check if the window state is fullscreen, as we need to pass that to the Screen.SetResolution method
        bool fullscreen = savedWindowState == 2;
        savedResolutionState = value;
        switch (value)
        {
            case 0: // 2560x1440
                Screen.SetResolution(2560, 1440, fullscreen);
                break;
            case 1: // 1920x1080
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            case 2: // 1280x720
                Screen.SetResolution(1280, 720, fullscreen);
                break;
        }
    }

    public void FPSCapChanged()
    {
        Application.targetFrameRate = int.Parse(fpsCap.text);
        savedFpsCap = int.Parse(fpsCap.text);
    }

    public void VSyncChanged()
    {
        if (!savedVSyncState) // Turn VSync off
        {
            QualitySettings.vSyncCount = 0; // VSync turned off
            VSyncCheckmark.SetActive(false);
            savedVSyncState = !savedVSyncState;
        }
        else // Turn VSync on
        {
            QualitySettings.vSyncCount = 1; // Vsync On
            VSyncCheckmark.SetActive(true);
            savedVSyncState = !savedVSyncState;
        }
    }
}
