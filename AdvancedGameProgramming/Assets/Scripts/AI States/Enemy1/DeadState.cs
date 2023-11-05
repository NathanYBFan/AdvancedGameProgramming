using UnityEngine;

public class DeadState : FSMState
{
    private EnemyController monster;

    //Constructor
    public DeadState(EnemyController controller)
    {
        stateID = FSMStateID.Dead;
        monster = controller;
    }

    //Reason
    public override void Reason(Transform player, Transform npc)
    {

    }

    //Act
    public override void Act(Transform player, Transform npc)
    {
        if (!monster.isDead)
        {
            monster.isDead = true;
            monster.StartDeath();
        }
    }
}
