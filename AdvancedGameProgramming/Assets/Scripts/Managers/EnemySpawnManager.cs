using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager _Instance { get; private set; }

    [SerializeField]
    private GameObject[] enemyPrefabList;

    [SerializeField]
    public List<EnemyController> enemyInstantiatedList;

    [SerializeField]
    private Collider spawnArea;

    [SerializeField]
    private Transform enemyContainer;

    [SerializeField]
    private Transform patrolPoint;

    public Collider SpawnArea { get { return spawnArea; } }
    public Transform PatrolPoint { get { return patrolPoint; } }

    private void Awake()    
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Extra Exp Manager singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }

    private void Start()
    {
        StartCoroutine(EnemySpawnLoop());
    }

    private IEnumerator EnemySpawnLoop()
    {
        if (enemyPrefabList.Length == 0) StopAllCoroutines();
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(3f);
        }
    }

    private void SpawnEnemies ()
    {
        foreach (var enemy in enemyPrefabList)
        {
            if (enemy != null)
            {
                int spawnAmount = GetSpawnRandomAmount();
                Vector3 spawnLocation = GetSpawnRandomLocation();
                for (int i = 0; i < spawnAmount; i++)
                {
                    Instantiate(enemy, spawnLocation, Quaternion.identity);
                }
            }
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

    public Transform GetEnemyContainer() { return enemyContainer; }

}
