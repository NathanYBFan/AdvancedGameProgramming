using NaughtyAttributes;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("WhatObjectToDestroy")]
    private GameObject objectToDestroy;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long to wait before despawning itself")]
    private float despawnTimer = 10f;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Amount of XP to give on pickup")]
    private int OrbXPMin = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Amount of XP to give on pickup")]
    private int OrbXPMax = 3;

    [Foldout("Specs")]
    [SerializeField] [ReadOnly] [Tooltip("The amount of xp to give to the player when/if picked up")]
    private int OrbXPValue;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(objectToDestroy, despawnTimer);
        OrbXPValue = Random.Range(OrbXPMin, OrbXPMax);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<GameCharacterStats>().PickedUpXP(OrbXPValue);
            Destroy(objectToDestroy);
        }
    }
}
