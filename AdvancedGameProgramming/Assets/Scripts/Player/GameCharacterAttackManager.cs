using NaughtyAttributes;
using UnityEngine;

public class GameCharacterAttackManager : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Hit box to spawn for attack 1 - Animation will be handled separately")]
    private GameObject attackOneHitBox;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Character transform to get rotation direction")]
    private Transform characterBody;

    // Spawns Attack 1 hitboxes
    public void LaunchAttackOne()
    {
        GameObject.Instantiate(attackOneHitBox, transform.position, characterBody.rotation);
    }
}
