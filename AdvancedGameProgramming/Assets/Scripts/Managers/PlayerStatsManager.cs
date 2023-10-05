using NaughtyAttributes;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Menu To adjust")]
    private UpgradesMenu upgradesMenu;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Player Level")]
    private int level = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Number of Sword stacks")]
    private int numbOfSwordStacks = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int baseDamage = 1;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("")]
    private int critChance = 1; // Out of 50

    public int Level { get { return level; } }
    public int NumbOfSwordStacks { get { return numbOfSwordStacks; } set { numbOfSwordStacks = value; } }
    public int BaseDamage { get { return baseDamage; } set { baseDamage += value; } }
    public int CritChance { get { return critChance; } set { critChance += value; } }

    public void LevelUp()
    {
        level++;
        OpenUpgradesMenu();
    }

    private void OpenUpgradesMenu()
    {
        upgradesMenu.gameObject.SetActive(true);
        upgradesMenu.GetComponent<UpgradesMenu>().OpenMenu();
        Time.timeScale = 0f;
    }
}
