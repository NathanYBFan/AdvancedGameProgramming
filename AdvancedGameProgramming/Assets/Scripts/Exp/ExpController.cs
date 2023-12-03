using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    // SERIALZIE FIELDS
    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("What object to destroy")]
    private GameObject objectToDestroy;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long to wait before despawning itself")]
    private float despawnTimer = 10f;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Amount of XP to give on pickup")]
    private int OrbXPMin = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Amount of XP to give on pickup")]
    private int OrbXPMax = 3;

    [Foldout("Specs")]
    [SerializeField] [ReadOnly] [Tooltip("The amount of xp to give to the player when/if picked up")]
    private int OrbXPValue;

    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(DespawnTimer()); // Despawn after time

        // Calculate values
        OrbXPValue = Random.Range(OrbXPMin, OrbXPMax);
        objectToDestroy.transform.parent = ExpManager._Instance.GetExpContainer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameCharacterStats._Instance.PickedUpXP(OrbXPValue);
            ExpManager._Instance.CollectOrb(objectToDestroy.transform);
        }
    }

    public void AttractOrb ()
    {
        float step = 1f * Time.deltaTime;
        StartCoroutine(ActivateAttractOrb(step));
    }

    public IEnumerator ActivateAttractOrb(float step)
    {
        objectToDestroy.transform.position = Vector3.MoveTowards(objectToDestroy.transform.position, PlayerManager._Instance.PlayerBody.position, step);
        yield return new WaitForEndOfFrame();
    }
    
    private IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTimer);
        ExpManager._Instance.CollectOrb(objectToDestroy.transform);
    }
}
