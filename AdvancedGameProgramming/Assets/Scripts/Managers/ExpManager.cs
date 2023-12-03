using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    // INSTANCE INITIALIZATION
    public static ExpManager _Instance { get; private set; }

    // SERIALIZE FIELDS
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private Transform expContainer;

    [Foldout("Script Dependancies"), ReadOnly]
    [SerializeField] [Tooltip("")]
    private List<Transform> activeOrbs;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private List<Transform> inActiveOrbs;

    // GETTERS
    public List<Transform> GetActiveOrbs() { return activeOrbs; }
    public Transform GetExpContainer() { return expContainer; }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Extra Exp Manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }

    public void CollectOrb(Transform orb)
    {
        // Set lists
        activeOrbs.Remove(orb);
        inActiveOrbs.Add(orb);

        orb.gameObject.SetActive(false);
    }

    public void SpawnOrb (Transform enemyTransform)
    {
        if (inActiveOrbs.Count <= 0) return; // If no available orbs to spawn, return

        Transform orbToSpawn = inActiveOrbs[0]; // Get orb to spawn

        // Set lists
        inActiveOrbs.Remove(orbToSpawn);
        activeOrbs.Add(orbToSpawn);

        orbToSpawn.position = enemyTransform.position; // Set to correct position
        orbToSpawn.gameObject.SetActive(true); // Enable orb in game
    }

    public void ResetAllOrbs()
    {
        if (activeOrbs.Count <= 0) return;
        for (int i = 0; i < activeOrbs.Count; i++)
            CollectOrb(activeOrbs[i]);
    }
}
