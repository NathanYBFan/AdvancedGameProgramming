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

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private float scale = 1;

    // Spawns Attack 1 hitboxes
    public void LaunchAttackOne()
    {
        GameObject attack = GameObject.Instantiate(attackOneHitBox, transform.position, characterBody.rotation);
        attack.transform.localScale = Vector3.one * scale;
    }

    public void IncreaseScale(float scaleToAdd)
    {
        scale += scaleToAdd;
    }
}
