using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _Instance;

    [SerializeField]
    public AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip[] audioClips;

    [SerializeField]
    private AudioClip[] swordSwings;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a repeated AudioManager");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

    public void PlayJumpSound()
    {
        playerAudioSource.pitch = (Random.Range(0.7f, 1f));
        playerAudioSource.PlayOneShot(audioClips[0]);
    }

    public void PlaySwordSwing()
    {
        playerAudioSource.pitch = 1;
        playerAudioSource.PlayOneShot(swordSwings[Random.Range(0, 2)]);
    }
}
