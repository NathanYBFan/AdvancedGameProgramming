using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

public class EntityNavMeshMovement : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Target to moveTowards")]
    private Transform target;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Agent to move")]
    private NavMeshAgent agent;

    private void Start()
    {
        target = PlayerManager._Instance.PlayerBody;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetMoveSpeed(float newSpeed) { agent.speed = newSpeed; }

    public float GetMoveSpeed() { return agent.speed; }
}
