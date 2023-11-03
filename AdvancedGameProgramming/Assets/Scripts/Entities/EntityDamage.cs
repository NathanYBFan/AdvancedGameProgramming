using NaughtyAttributes;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Placeables"))
        {
            if (other.CompareTag("Player"))
            {
                GameCharacterStats gcs = other.GetComponentInChildren<GameCharacterStats>();
                gcs.AddCurrentHP(-damage);
            }
            else
            {
                EntityHP entityHP = other.GetComponentInChildren<EntityHP>();
                entityHP.TakeDamage(damage);
            }
        }
    }
}
