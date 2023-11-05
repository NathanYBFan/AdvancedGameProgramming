using UnityEngine;

public class ChaseState : FSMState
{
    private EntityHP enemyHpScript;
    private EnemyController enemyController;

    // Constructor
    public ChaseState(EnemyController enemyController, EntityHP enemyHp)
    {
        stateID = FSMStateID.Chase;
        this.enemyController = enemyController;
        enemyHpScript = enemyHp;
    }


    // Reason
    public override void Reason(Transform player, Transform npc)
    {
        if (enemyHpScript.CheckIsDead()) // Transition to dead
        {
            enemyController.EnemyStopMove();
            enemyController.PerformTransition(Transition.NoHealth);
            return;
        }
        else if (enemyController.ShouldDash()) // Transition to Dash
        {
            enemyController.StartDash();

            enemyController.enemyAnimator.SetBool("IsWalking", false);
            enemyController.PerformTransition(Transition.DashUp);

            enemyController.EntityNavMeshMovement.SetTarget(PlayerManager._Instance.PlayerBody);
            enemyController.EntityNavMeshMovement.SetMoveSpeed(10f);
            return;
        }
        else if (!enemyController.SpotPlayer()) // Transition to patrol
        {
            enemyController.EntityNavMeshMovement.SetTarget(EnemySpawnManager._Instance.PatrolPoint);
            enemyController.PerformTransition(Transition.Patrol);
            return;
        }
    }

    //Act
    public override void Act(Transform player, Transform npc)
    {

    }
}
