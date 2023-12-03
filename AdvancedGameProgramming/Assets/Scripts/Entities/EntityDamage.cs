using NaughtyAttributes;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{
    [Foldout("Specs")]
    [SerializeField] [Tooltip("Damage the enemy should do")]
    private int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Placeables"))
        {
            if (other.CompareTag("Player"))
                GameCharacterStats._Instance.AddCurrentHP(-damage);
            else
            {
                EntityHP entityHP = other.GetComponentInChildren<EntityHP>();
                entityHP.TakeDamage(damage);
            }
        }
    }
}
