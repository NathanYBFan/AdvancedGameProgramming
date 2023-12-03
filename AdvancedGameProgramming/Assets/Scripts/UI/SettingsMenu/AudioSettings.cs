using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using NaughtyAttributes;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Initializations")]
    [SerializeField, Required] private AudioMixer audioMixer;
    [SerializeField, Required] private Slider masterVolumeSlider;
    [SerializeField, Required] private Slider musicVolumeSlider;
    [SerializeField, Required] private Slider playerVolumeSlider;
    [SerializeField, Required] private Slider enemyVolumeSlider;

    public float masterVolume;
    public float musicVolume;
    public float playerVolume;
    public float enemyVolume;
    public bool firstTimeUpdate;

    // Start is called before the first frame update
    void OnEnable()
    {
        masterVolumeSlider.value = masterVolume;
        musicVolumeSlider.value = musicVolume;
        playerVolumeSlider.value = playerVolume;
        enemyVolumeSlider.value = enemyVolume;
    }

    public void MasterVolumeChanged()
    {
        masterVolume = masterVolumeSlider.value;
        audioMixer.SetFloat("Master", masterVolume);
    }
    public void MusicVolumeChanged()
    {
        musicVolume = musicVolumeSlider.value;
        audioMixer.SetFloat("Music", musicVolume);
    }
    public void PlayerVolumeChanged()
    {
        playerVolume = playerVolumeSlider.value;
        audioMixer.SetFloat("Player", playerVolume);
    }
    public void EnemyVolumeChanged()
    {
        enemyVolume = enemyVolumeSlider.value;
        audioMixer.SetFloat("Enemy", enemyVolume);
    }
}
