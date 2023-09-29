using NaughtyAttributes;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [Foldout("Specs")]
    [SerializeField] [Tooltip("Player Level")]
    private int level = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Number of Sword stacks")]
    private int numbOfSwordStacks = 0;

    public int Level { get { return level; } set { level = value; } }
    public int NumbOfSwordStacks { get { return numbOfSwordStacks; } set { numbOfSwordStacks = value; } }
}
