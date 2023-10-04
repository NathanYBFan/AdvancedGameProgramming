using NaughtyAttributes;
using UnityEngine;

public class DashTrailBehaviour : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("What object to destroy")]
    private GameObject objectToDestroy;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long to wait before despawning itself")]
    private float despawnTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(objectToDestroy, despawnTimer);
    }
}
