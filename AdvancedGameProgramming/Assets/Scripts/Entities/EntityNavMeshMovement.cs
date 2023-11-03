using UnityEngine;
using UnityEngine.AI;

public class EntityNavMeshMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.Find("PlayerBody").transform;
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
}
