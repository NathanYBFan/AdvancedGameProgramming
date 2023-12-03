using NaughtyAttributes;
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

    // Inputs
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !menuManager.IsSettingsMenuOpened() && !menuManager.IsUpgradeMenuOpened())
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
            GameCharacterStats._Instance.AddCurrentHP(1);
        else if (Input.GetKeyDown(KeyCode.O))   // DECREASE HP
            GameCharacterStats._Instance.AddCurrentHP(-1);

        if (Input.GetKeyDown(KeyCode.L))        // INCREASE MAX HP
            GameCharacterStats._Instance.AddMaxHP(1);
        else if (Input.GetKeyDown(KeyCode.K))   // DECREASE MAX HP
            GameCharacterStats._Instance.AddMaxHP(-1);

        if (Input.GetKeyDown(KeyCode.J))        // INCREASE XP
            GameCharacterStats._Instance.PickedUpXP(1);

        if (Input.GetKeyDown(KeyCode.I))        // Level Up
            PlayerManager._Instance.LevelUp();

        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
