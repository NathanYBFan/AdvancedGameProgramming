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

    [Header("Direction of inputs")]
    [SerializeField] [ReadOnly] [Tooltip("Base movement direction")]
    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    // Inputs
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
            characterController.Jump();
        if (Input.GetButtonDown("Fire1"))
            characterAttackManager.LaunchAttackOne();
        if (Input.GetButtonDown("Fire2"))
            characterController.Dash();

        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
