using NaughtyAttributes;
using UnityEngine;

public class GameCharacterStats : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Current amount of XP")]
    private PlayerStatsManager playerStatsManager;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current amount of XP")]
    private int xp = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("XP needed before level up")]
    private int maxXP = 10;

    public void PickedUpXP(int expPickedUp)
    {
        xp += expPickedUp;
        CheckMaxXP();
    }

    private void CheckMaxXP()
    {
        if (xp >= maxXP) // If max xp is reached
        {
            playerStatsManager.Level++;
            xp = xp - maxXP;
            maxXP *= 2;
        }
    }
}
