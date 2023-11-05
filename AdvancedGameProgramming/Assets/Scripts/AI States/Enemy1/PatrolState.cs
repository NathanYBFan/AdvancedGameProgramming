using UnityEngine;

public class PatrolState : FSMState
{
    private EntityHP enemyHP;
    private EnemyController enemyController;
    private Transform patrolPoint;
    public PatrolState(EnemyController enemyController, EntityHP enemyHP)
    {
        stateID = FSMStateID.Patrol;
        this.enemyHP = enemyHP;
        this.enemyController = enemyController;
        patrolPoint = EnemySpawnManager._Instance.PatrolPoint;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if (enemyHP.CheckIsDead())
        {
            enemyController.EnemyStopMove();
            enemyController.PerformTransition(Transition.NoHealth);
            return;
        }

        else if (enemyController.SpotPlayer())
        {
            enemyController.EnemyStopMove();
            enemyController.enemyAnimator.SetTrigger("PlayerSpotted");
            
            enemyController.EntityNavMeshMovement.SetTarget(PlayerManager._Instance.PlayerBody);
            enemyController.PerformTransition(Transition.SeePlayer);
            return;
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        enemyController.EntityNavMeshMovement.SetTarget(patrolPoint);
    }
}
