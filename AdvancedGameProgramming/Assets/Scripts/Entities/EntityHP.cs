using NaughtyAttributes;
using UnityEngine;

public class EntityHP : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The top level body of the entities body")]
    private GameObject enemyOrigin;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("EXP Prefab object to drop on death")]
    private GameObject expPrefab;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current HP of the enemy")]
    private int currentHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Maximum HP the enemy has")]
    private int maxHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("If the entity should drop an EXP orb")]
    private bool shouldDropEXP = true;

    // No regen

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (currentHP <= 0)
        {
            if (shouldDropEXP)
                Instantiate(expPrefab, transform.position + transform.up, Quaternion.identity);

            Destroy(enemyOrigin);
        }
    }
}
