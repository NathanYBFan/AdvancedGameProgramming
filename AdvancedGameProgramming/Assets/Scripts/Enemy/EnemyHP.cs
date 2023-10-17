using NaughtyAttributes;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("")]
    private GameObject EnemyParent;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int currentHP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int maxHP = 10;

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
            Destroy(EnemyParent);
        }
    }
}
