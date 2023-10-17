using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : FSMState
{
    private bool deathStarted = false;

    private EnemyController monster;

    //Constructor
    public DeadState(EnemyController controller)
    {
        stateID = FSMStateID.Dead;
        monster = controller;
        curSpeed = 0.0f;
        curRotSpeed = 0.0f;
    }

    //Reason
    public override void Reason(Transform player, Transform npc)
    {
    }

    //Act
    public override void Act(Transform player, Transform npc)
    {
        if (!deathStarted)
        {
            monster.StartDeath();
        }
    }
}
