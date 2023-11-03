using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager _Instance { get; private set; }

    [SerializeField]
    private GameObject[] enemyList;

    [SerializeField]
    private Collider spawnArea;

    [SerializeField]
    private Transform enemyContainer;


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
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(2f);
        }
    }

    private void SpawnEnemies ()
    {
        foreach (var enemy in enemyList)
        {
            if (enemy != null)
            {
                int spawnAmount = GetSpawnRandomAmount();
                Vector3 spawnLocation = GetSpawnRandomLocation();
                for (int i = 0; i < spawnAmount; i++)
                {
                    Debug.Log("Enemy Spawned");
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

    private Vector3 GetSpawnRandomLocation()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        randomPos.y = transform.position.y;
        randomPos.z = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        return randomPos;
    }

    public Transform GetEnemyContainer() { return enemyContainer; }

}
