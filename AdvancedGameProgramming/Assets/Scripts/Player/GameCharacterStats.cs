using NaughtyAttributes;
using UnityEngine;

public class GameCharacterStats : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Current amount of XP")]
    private PlayerStatsManager playerStatsManager;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("XP bar to update")]
    private XPBar xpBar;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("HP bar to update")]
    private HPBar hpBar;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current amount of XP")]
    private int xp = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("XP needed before level up")]
    private int maxXP = 10;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current amount of HP")]
    private int hp = 3;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Max amount of XP")]
    private int maxHp = 3;

    // Getters
    public float Xp { get { return xp; } }
    public float MaxXP { get {  return maxXP; } }
    public int HP { get { return hp; } }
    public int MaxHp { get {  return maxHp; } }

    public void AddMaxHP(int maxHPToAdd)
    {
        if (maxHPToAdd < 0)
        {
            if (hp == maxHp)
                hp += maxHPToAdd;
        }
        else
            hp += maxHPToAdd;

        maxHp += maxHPToAdd;
        
        if (maxHp < 1)
            maxHp = 1; 
        if (hp < 1)
            hp = 1; // Dead

        hpBar.MaxHPChanged();
    }

    public void AddCurrentHP(int hPToAdd)
    {
        hp += hPToAdd;

        if (hp > maxHp) // Overheal
            hp = maxHp;
        if (hp < 0) // Dead
        {
            hp = 0;
            return;
        }

        hpBar.CurrentHPChanged();
    }

    public void PickedUpXP(int expPickedUp)
    {
        xp += expPickedUp;
        CheckMaxXP();
    }

    private void CheckMaxXP()
    {
        if (xp >= maxXP) // If max xp is reached
        {
            Debug.Log("Level up");
            playerStatsManager.LevelUp();
            xp = xp - maxXP;
            maxXP *= 2;
        }
        xpBar.RenderNewText();
    }
}
