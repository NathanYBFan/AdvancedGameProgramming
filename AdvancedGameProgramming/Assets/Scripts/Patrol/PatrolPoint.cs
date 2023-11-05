using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.transform.position = EnemySpawnManager._Instance.GetSpawnRandomLocation();
        }
    }
}
