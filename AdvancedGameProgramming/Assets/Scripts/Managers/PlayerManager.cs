using NaughtyAttributes;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager _Instance { get; private set; }

    [Foldout("Script Dependancies"), Required]
    [SerializeField] [Tooltip("Menu To adjust")]
    private UpgradesMenu upgradesMenu;

    [Foldout("Script Dependancies"), Required]
    [SerializeField] [Tooltip("Player Body")]
    private Transform playerBody;

    [Foldout("Script Dependancies"), Required]
    [SerializeField] [Tooltip("Player Spawn Point")]
    private Transform playerSpawnPoint;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Player Level")]
    private int level = 0;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Number of Sword stacks")]
    private int numbOfSwordStacks = 0;

    public int Level { get { return level; } set { level = value; } }
    public int NumbOfSwordStacks { get { return numbOfSwordStacks; } set { numbOfSwordStacks = value; } }
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
        EffectsManager._Instance.PlayerSpawn();
    }
}
