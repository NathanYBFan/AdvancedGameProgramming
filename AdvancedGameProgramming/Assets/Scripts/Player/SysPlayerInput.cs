using NaughtyAttributes;
using UnityEngine;

public class SysPlayerInput : MonoBehaviour
{
    [SerializeField] [Required]
    private GameCharacterController characterController;
    [SerializeField] [Required]
    private GameCharacterAttackManager characterAttackManager = null;
    
    private float horizontal;
    private float vertical;
    private bool jumpPressed;
    public bool JumpPressed { get { return jumpPressed; } }
    
    [SerializeField] [ReadOnly]
    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");
        
        if (jumpPressed)
            characterController.Jump();
        if (Input.GetButtonDown("Fire1"))
            characterAttackManager.LaunchAttackOne();

        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
