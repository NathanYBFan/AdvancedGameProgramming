using NaughtyAttributes;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager _Instance { get; private set; }

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private ParticleSystem playerHurtEffect;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private ParticleSystem playerMoveTrailEffect;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private ParticleSystem playerAreaDamageEffect;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Extra Effects manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }

    public void PlayerSpawn()
    {
        playerMoveTrailEffect.Play();
        playerAreaDamageEffect.Play();
    }

    public void PlayPlayerHurtEffect()
    {
        playerHurtEffect.Play(false);
    }

    public void StopAllEffects()
    {
        playerHurtEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        playerMoveTrailEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        playerAreaDamageEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
