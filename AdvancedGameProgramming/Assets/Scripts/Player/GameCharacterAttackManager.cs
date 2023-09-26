using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterAttackManager : MonoBehaviour
{
    [SerializeField]
    private GameObject attackOneHitBox;
    [SerializeField]
    private Transform characterBody;

    public void LaunchAttackOne()
    {
        GameObject.Instantiate(attackOneHitBox, transform.position, characterBody.rotation);
    }
}
