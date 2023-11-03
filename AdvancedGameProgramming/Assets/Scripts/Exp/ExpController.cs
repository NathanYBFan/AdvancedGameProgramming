using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField][Required][Tooltip("What object to destroy")]
    private GameObject objectToDestroy;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Rerference to object to move")]
    private Transform objectToBounce;

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

    [Foldout("Specs")]
    [SerializeField] [Tooltip("The curve the bobbing animation should follow")]
    private AnimationCurve myCurve;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Speed at which the bob should happen")]
    private float speed = 5f;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("MaxHeight the xp should bob")]
    private float height = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(objectToDestroy, despawnTimer);
        OrbXPValue = Random.Range(OrbXPMin, OrbXPMax);
        objectToDestroy.transform.parent = ExpManager._Instance.GetExpContainer();
        ExpManager._Instance.expOrbs.Add(objectToDestroy.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<GameCharacterStats>().PickedUpXP(OrbXPValue);
            ExpManager._Instance.expOrbs.Remove(objectToDestroy.transform);
            Destroy(objectToDestroy);
        }
    }

    void Update()
    {
        // Calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + objectToBounce.position.y;
        // Set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
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

}
