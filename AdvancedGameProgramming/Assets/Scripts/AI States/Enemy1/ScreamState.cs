using UnityEngine;

public class ScreamState : FSMState
{
    private EntityHP enemyHP;
    private EnemyController enemyController;

    public ScreamState(EnemyController enemyController, EntityHP enemyHP, Animator animator)
    {
        stateID = FSMStateID.Scream;
        this.enemyHP = enemyHP;
        this.enemyController = enemyController;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if (!enemyController.screamFinished) return;
        enemyController.EnemyCanMove();
        enemyController.screamFinished = false;
        if (enemyHP.CheckIsDead())
        {
            enemyController.EnemyStopMove();
            enemyController.PerformTransition(Transition.NoHealth);
            return;
        }
        else if (!enemyController.ShouldDash())
        {
            enemyController.enemyAnimator.SetBool("IsWalking", true);
            enemyController.PerformTransition(Transition.DashDown);

            enemyController.EntityNavMeshMovement.SetTarget(PlayerManager._Instance.PlayerBody);
            enemyController.EntityNavMeshMovement.SetMoveSpeed(3f);
            return;
        }
        else if (enemyController.ShouldDash())
        {
            enemyController.StartDash();

            enemyController.enemyAnimator.SetBool("IsWalking", false);
            enemyController.PerformTransition(Transition.DashUp);
            return;
        }
        else if (!enemyController.SpotPlayer())
        {
            enemyController.EnemyStopMove();
            enemyController.PerformTransition(Transition.Patrol);
            return;
        }
    }

    public override void Act(Transform player, Transform npc)
    {

    }
}
