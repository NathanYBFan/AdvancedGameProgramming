using UnityEngine;

public class DashState : FSMState
{
    private EntityHP enemyHP;
    private EnemyController enemyController;

    public DashState(EnemyController enemyController, EntityHP enemyHP)
    {
        stateID = FSMStateID.Dashing;
        this.enemyHP = enemyHP;
        this.enemyController = enemyController;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if (enemyHP.CheckIsDead())
        {
            enemyController.EnemyStopMove();
            enemyController.PerformTransition(Transition.NoHealth);
            return;
        }
    }

    public override void Act(Transform player, Transform npc)
    {

    }
}
