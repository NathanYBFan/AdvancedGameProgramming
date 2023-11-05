using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager _Instance { get; private set; }

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Menu To adjust")]
    private UpgradesMenu upgradesMenu;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Player Body")]
    private Transform playerBody;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Player Spawn Point")]
    private Transform playerSpawnPoint;

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
    public Transform PlayerBody { get { return playerBody; } }
    public Transform PlayerSpawnPoint { get { return playerSpawnPoint; } }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.Log("Destroyed a repeated playerManager");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

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

    public void RespawnPlayer()
    {
        playerBody.position = playerSpawnPoint.position;
    }
}
