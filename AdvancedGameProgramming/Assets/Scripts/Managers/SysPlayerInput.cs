using NaughtyAttributes;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class SysPlayerInput : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Required] [Tooltip("Character controller script to send jump and dash inputs")]
    private GameCharacterController characterController;

    [Foldout("Script Dependencies")]
    [SerializeField] [Required] [Tooltip("Character attack manager script to send attack inputs")]
    private GameCharacterAttackManager characterAttackManager;

    [Foldout("Script Dependencies")]
    [SerializeField] [Required] [Tooltip("Character attack manager script to send attack inputs")]
    private GameCharacterDash characterDashController;

    [Foldout("Script Dependencies")]
    [SerializeField] [Required] [Tooltip("Manage menu interactions")]
    private MenuManager menuManager;

    [Foldout("Specs")]
    [SerializeField] [ReadOnly] [Tooltip("Base movement direction")]
    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    [SerializeField] private GameCharacterStats characterStats; // To be removed - Debug only
    [SerializeField] private PlayerStatsManager playerStatsManager;
    // Inputs
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !menuManager.IsSettingsMenuOpened())
            menuManager.OpenPauseMenu();

        if (Time.timeScale == 0f) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
            characterController.Jump();

        if (Input.GetButtonDown("Fire1"))
            characterAttackManager.LaunchAttackOne();

        if (Input.GetButtonDown("Fire2"))
            characterDashController.AttemptDash();

        // BELOW ARE ALL DEBUG KEYBINDS
        if (Input.GetKeyDown(KeyCode.P))        // INCREASE HP
            characterStats.AddCurrentHP(1);
        else if (Input.GetKeyDown(KeyCode.O))   // DECREASE HP
            characterStats.AddCurrentHP(-1);

        if (Input.GetKeyDown(KeyCode.L))        // INCREASE MAX HP
            characterStats.AddMaxHP(1);
        else if (Input.GetKeyDown(KeyCode.K))   // DECREASE MAX HP
            characterStats.AddMaxHP(-1);

        if (Input.GetKeyDown(KeyCode.J))        // INCREASE XP
            characterStats.PickedUpXP(1);

        if (Input.GetKeyDown(KeyCode.I))        // Level Up
            playerStatsManager.LevelUp();

        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
