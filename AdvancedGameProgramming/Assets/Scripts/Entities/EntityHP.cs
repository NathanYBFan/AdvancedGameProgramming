using NaughtyAttributes;
using UnityEngine;

public class EntityHP : MonoBehaviour
{
    // SERIALIZE FIELDS
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The top level body of the entities body")]
    private GameObject enemyOrigin;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current HP of the enemy")]
    private int currentHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Maximum HP the enemy has")]
    private int maxHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private bool shouldSpawnEXP = true;

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        CheckIsDead();
    }

    public void CheckIsDead()
    {
        if (currentHP > 0) return; // If not dead return (No need to check)
        
        currentHP = maxHP; // Reset HP

        if (shouldSpawnEXP)
            ExpManager._Instance.SpawnOrb(enemyOrigin.transform);
        EnemySpawnManager._Instance.EnemyDeathAction(enemyOrigin.transform, true);
    }

    public void ResetHealth()
    {
        currentHP = maxHP;
    }
}
