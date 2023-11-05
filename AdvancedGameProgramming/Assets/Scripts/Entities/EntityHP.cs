using NaughtyAttributes;
using UnityEngine;

public class EntityHP : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The top level body of the entities body")]
    private GameObject enemyOrigin;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current HP of the enemy")]
    private int currentHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Maximum HP the enemy has")]
    private int maxHP = 10;

    // No regen

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    public bool CheckIsDead()
    {
        return (currentHP <= 0);
    }
}
