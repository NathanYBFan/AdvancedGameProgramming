using NaughtyAttributes;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : AdvancedFSM
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The top level body of the enemy's body")]
    private Transform enemyOrigin;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The Entity's hp script")]
    private EntityHP enemyHP;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The Entity's hp script")]
    private EntityNavMeshMovement entityNavMeshMovement;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("EXP Prefab object to drop on death")]
    private GameObject expPrefab;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("SpawnPoint of enemy raycast to player")]
    private Transform rayCastSpawnPoint;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("SpawnPoint of enemy raycast to player")]
    public Animator enemyAnimator;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("If the entity should drop an EXP orb")]
    private bool shouldDropEXP = true;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("The time the enemy can dash for")]
    private float dashTime = 2f;

    [Foldout("Specs")]
    [SerializeField][Tooltip("The time the enemy can dash for")]
    private float dashCooldown = 5f;

    [Foldout("Specs")]
    [SerializeField][Tooltip("The patrol points raycast layer mask")]
    private LayerMask patrolPointLayerMask;

    [SerializeField]
    private TextMeshProUGUI debugEnemyStateText; // TO BE DELETED

    public bool canSeePlayer = false;

    public bool isDead = false;
    public bool screamFinished = false;

    private float dashCooldownCounter = 0f;
    private float prevMoveSpeed;



    public EntityNavMeshMovement EntityNavMeshMovement { get { return entityNavMeshMovement; } }
    private void Start()
    {
        EnemySpawnManager._Instance.enemyInstantiatedList.Add(this);
        enemyOrigin.parent = EnemySpawnManager._Instance.GetEnemyContainer();
        dashCooldownCounter = dashCooldown;
        Initialize();
    }

    private string GetStateString()
    {
        string state = "NONE";

        if (CurrentState.ID == FSMStateID.Dead)
            state = "DEAD";
        else if (CurrentState.ID == FSMStateID.Chase)
            state = "CHASE";
        else if (CurrentState.ID == FSMStateID.Dashing)
            state = "DASH";
        else if (CurrentState.ID == FSMStateID.Patrol)
            state = "PATROL";
        else if (CurrentState.ID == FSMStateID.Scream)
            state = "SCREAM";
        return state;
    }

    protected override void Initialize()
    {
        playerTransform = PlayerManager._Instance.PlayerBody;
        ConstructFSM();
    }

    protected override void FSMUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.Reason(playerTransform, transform);
            CurrentState.Act(playerTransform, transform);
        }
        if (CurrentState.ID == FSMStateID.Chase)
            dashCooldownCounter -= Time.deltaTime;
        
        debugEnemyStateText.text = "Enemy State: " + GetStateString();
    }

    private void ConstructFSM()
    {
        //
        // Create States
        //
        PatrolState patrolState = new PatrolState(this, enemyHP);
        ScreamState screamState = new ScreamState(this, enemyHP, enemyAnimator);
        ChaseState chaseState = new ChaseState(this, enemyHP);
        DashState dashState = new DashState(this, enemyHP);
        DeadState deadState = new DeadState(this);

        // Create Transitions
        patrolState.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        patrolState.AddTransition(Transition.SeePlayer, FSMStateID.Scream);

        chaseState.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        chaseState.AddTransition(Transition.DashUp, FSMStateID.Dashing);
        chaseState.AddTransition(Transition.Patrol, FSMStateID.Patrol);

        dashState.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        dashState.AddTransition(Transition.DashDown, FSMStateID.Chase);

        screamState.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        screamState.AddTransition(Transition.DashUp, FSMStateID.Dashing);
        screamState.AddTransition(Transition.DashDown, FSMStateID.Chase);

        //Add all states to the state list
        AddFSMState(patrolState);
        AddFSMState(chaseState);
        AddFSMState(dashState);
        AddFSMState(screamState);
        AddFSMState(deadState);
    }

    public void StartDeath()
    {
        enemyAnimator.SetTrigger("IsDead");
        StartCoroutine(DeathCoroutine());
    }

    public IEnumerator DeathCoroutine()
    {
        entityNavMeshMovement.SetMoveSpeed(0f);
        yield return new WaitForSeconds(1f);

        if (shouldDropEXP)
            Instantiate(expPrefab, transform.position + Vector3.up, Quaternion.identity);
    }

    public void StartDash()
    {
        StartCoroutine(DashCooldownCoroutine());
    }

    public IEnumerator DashCooldownCoroutine()
    {
        enemyAnimator.SetBool("IsWalking", false);
        entityNavMeshMovement.SetMoveSpeed(10f);

        yield return new WaitForSeconds(dashTime);
        
        entityNavMeshMovement.SetMoveSpeed(3f);
        enemyAnimator.SetBool("IsWalking", true);
        PerformTransition(Transition.DashDown);
        ResetDashTimer();
    }

    public bool ShouldDash() { return (dashCooldownCounter <= 0); }

    public void ResetDashTimer() { dashCooldownCounter = dashCooldown; }

    public bool SpotPlayer()
    {
        Vector3 aimDirection = PlayerManager._Instance.PlayerBody.position - rayCastSpawnPoint.position;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(rayCastSpawnPoint.position, aimDirection, 25f);
        Debug.DrawRay(rayCastSpawnPoint.position, aimDirection, Color.red);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (!canSeePlayer)
                {
                    canSeePlayer = true;
                }
                return true;
            }
        }
        canSeePlayer = false;
        return false;
    }

    public void EnemyCanMove()
    {
        entityNavMeshMovement.SetMoveSpeed(prevMoveSpeed);
    }

    public void EnemyStopMove()
    {
        prevMoveSpeed = entityNavMeshMovement.GetMoveSpeed();
        entityNavMeshMovement.SetMoveSpeed(0f);
    }
}
