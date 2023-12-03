using NaughtyAttributes;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class GameCharacterStats : MonoBehaviour
{
    // INSTANCE INITIALIZATION
    public static GameCharacterStats _Instance { get; private set; }

    // SERIALIZE FIELDS
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
    private int maxXP = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Current amount of HP")]
    private int hp = 3;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Max amount of XP")]
    private int maxHp = 3;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Max amount of XP")]
    private int xpBuff = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Max amount of XP")]
    private int xpMultiplier = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int baseDamage = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int damageMultiplier = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private Vector3 areaDamageScale = new Vector3(5f, 0f, 5f);

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int upgradeOptions = 2;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private float cakeSize = 0.5f;
    
    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private float attackSizeScale = 1f;


    // Getters & Setters
    public int Xp { get { return xp; } set { xp = value; } }
    public int MaxXP { get { return maxXP; } set { maxXP = value;} }
    public int XpBuff { get { return xpBuff; } set { xpBuff = value; } }
    public int XpMultiplier { get { return xpMultiplier; } set { xpMultiplier = value; } }
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int BaseDamage { get { return baseDamage; } set { baseDamage = value; } }
    public int DamageMultiplier { get { return damageMultiplier; } set { damageMultiplier = value; } }
    public Vector3 AreaDamageScale { get { return areaDamageScale; } set { areaDamageScale = value; } }
    public int UpgradeOptions { get { return upgradeOptions; } set { upgradeOptions = value; } }
    public float CakeSize { get { return cakeSize; } set { cakeSize = value; } }
    public float AttackSizeScale { get { return attackSizeScale; } set { attackSizeScale = value; } }


    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Extra CharacterStat singleton destroyed");
            Destroy(this);
        }
        else
            _Instance = this;
    }


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

    public void AddCurrentHP(int hpToAdd)
    {
        hp += hpToAdd;

        if (hp > maxHp) // Overheal
            hp = maxHp;

        if (hpToAdd < 0) // Take damage not heal
            EffectsManager._Instance.PlayPlayerHurtEffect();

        if (hp <= 0) // Dead
        {
            hp = maxHp;
            EffectsManager._Instance.StopAllEffects();
            GameManager._Instance.StartLoadLevel(GameManager._Instance.LevelNames[4]);
        }

        hpBar.CurrentHPChanged();
    }

    public void PickedUpXP(int xpPickedUp)
    {
        xp += (xpPickedUp + xpBuff) * xpMultiplier;
        CheckMaxXP();
    }

    private void CheckMaxXP()
    {
        if (xp >= maxXP) // If max xp is reached
        {
            PlayerManager._Instance.LevelUp();
            xp = xp - maxXP;
            int newMaxHP = Mathf.RoundToInt(Mathf.Pow(Mathf.Sqrt(PlayerManager._Instance.Level), 3f));
            maxXP = newMaxHP;
        }
        xpBar.RenderNewText();
    }

    public void AddXpBuff(int xpToAdd)
    {
        xpBuff = xpToAdd;
    }

    public void SetXpMultiplayer(int xpMultiplierToAdd)
    {
        xpMultiplier = xpMultiplierToAdd;
    }

    public int GetDamageOutput()
    {
        return baseDamage * damageMultiplier;
    }
}
