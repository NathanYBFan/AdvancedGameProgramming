using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // INSTANCE INITIALIZATION
    public static EnemySpawnManager _Instance { get; private set; }

    // SERIALIZE FIELDS
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private GameObject[] enemyPrefabList;

    [Foldout("Script Dependancies"), ReadOnly]
    [SerializeField] [Tooltip("List of active enemies in the scene")]
    public List<Transform> enemyActiveList;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("List of inactive enemies in the scene")]
    private List<Transform> enemyPoolList;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private Collider spawnArea;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private Transform enemyContainer;
 
    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private bool enemyPoolCanGrow = false;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int maxEnemies = 25;

    // GETTERS
    public Collider SpawnArea { get { return spawnArea; } }
    public Transform GetEnemyContainer() { return enemyContainer; }

    private void Awake()    
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Extra Enemy Manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(EnemySpawnLoop());
    }

    private IEnumerator EnemySpawnLoop()
    {
        if (enemyPrefabList.Length == 0) StopAllCoroutines();
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(10f);
        }
    }

    private void SpawnEnemies ()
    {
        int spawnAmount = GetSpawnRandomAmount();
        Vector3 spawnLocation = GetSpawnRandomLocation();
        for (int i = 0; i < spawnAmount; i++)
        {
            if (enemyActiveList.Count == maxEnemies) return; // If therae are too many enemies exit loop
            if (enemyPoolList.Count == 0) // If pool list is empty
            {
                if (enemyPoolCanGrow) // If pool list is allowed to grow
                    Instantiate(enemyPrefabList[0], spawnLocation, Quaternion.identity); // Instantiate new enemy

                else return; // Otherwise quit
            }
            EnemySpawnAction(enemyPoolList[0], spawnLocation);
        }
    }

    private int GetSpawnRandomAmount ()
    {
        int placeHolderMin = 1;
        int placeHolderMax = 4;
        return Random.Range(placeHolderMin, placeHolderMax);
    }

    public Vector3 GetSpawnRandomLocation()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        randomPos.y = transform.position.y;
        randomPos.z = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        return randomPos;
    }

    public void EnemyDeathAction(Transform enemyTransform, bool countToTotal)
    {
        // Remove from active list
        enemyActiveList.Remove(enemyTransform);
        // Add to enemy inactive pool
        enemyPoolList.Add(enemyTransform);

        // Enemy Initialization
        enemyTransform.gameObject.SetActive(false);
    }
    public void EnemySpawnAction(Transform enemyTransform, Vector3 spawnLocation)
    {
        // Remove initialized enemy from pool
        enemyPoolList.Remove(enemyTransform);
        // Add initialized enemy to active pool
        enemyActiveList.Add(enemyTransform);

        // Enemy Initialization
        enemyTransform.position = spawnLocation;
        enemyTransform.GetComponentInChildren<EntityHP>().ResetHealth();
        enemyTransform.gameObject.SetActive(true);
    }

    public void ResetAllEnemies()
    {
        if (enemyActiveList.Count <= 0) return;
        for (int i = 0; i < enemyActiveList.Count; i++)
            EnemyDeathAction(enemyActiveList[i], false);
    }
}
