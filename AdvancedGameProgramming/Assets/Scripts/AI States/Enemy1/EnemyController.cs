using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class EnemyController : AdvancedFSM
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The top level body of the enemy's body")]
    private Transform enemyOrigin;

    private void Start()
    {
        EnemySpawnManager._Instance.enemyInstantiatedList.Add(this);
        enemyOrigin.parent = EnemySpawnManager._Instance.GetEnemyContainer();
    }
    private string GetStateString()
    {

        string state = "NONE";
        if (CurrentState.ID == FSMStateID.Dead)
        {
            state = "DEAD";
        }

        return state;
    }

    protected override void Initialize()
    {
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;
        ConstructFSM();
    }

    protected override void FSMUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.Reason(playerTransform, transform);
            CurrentState.Act(playerTransform, transform);
        }
    }


    private void ConstructFSM()
    {
        //
        //Create States
        //

        //Create the Dead state
        DeadState deadState = new DeadState(this);
        //there are no transitions out of the dead state


        //Add all states to the state list
        AddFSMState(deadState);
    }

    public void StartDeath()
    {
        //StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.2f);
        Destroy(gameObject);
    }

}
