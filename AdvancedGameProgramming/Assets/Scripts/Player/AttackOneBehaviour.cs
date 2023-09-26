using NaughtyAttributes;
using UnityEngine;

public class AttackOneBehaviour : MonoBehaviour
{
    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long to wait before despawning itself")]
    private float despawnTimer = 1f;
    private void Awake()
    {
        // Despawns Attack 1 Hitbox after set amount of seconds
        Destroy(gameObject, despawnTimer);
    }
}
