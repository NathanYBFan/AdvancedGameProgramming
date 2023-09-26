using NaughtyAttributes;
using UnityEngine;

public class GameCharacterController : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Script SysPlayerInput to pull movement inputs from")]
    private SysPlayerInput playerInput;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("The rigidbody attached to the character")]
    private Rigidbody rigidbody3D;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("How fast the player should move")]
    private float moveSpeed = 6f;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("The jump force of the player")]
    private float jumpForce = 500f;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("The dash force of the player")]
    private float dashForce = 20f;

    private bool isGrounded = true;

    public void FixedUpdate()
    {
        Vector3 direction = playerInput.Direction * moveSpeed;
        direction.y = rigidbody3D.velocity.y;
        if (direction.magnitude >= 0.1f)
            rigidbody3D.velocity = transform.forward + direction;

        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {

    }

    public void Jump()
    {
        if (isGrounded)
            rigidbody3D.AddForce(transform.up * jumpForce);
    }

    public void Dash()
    {
        rigidbody3D.velocity = transform.forward * dashForce;
    }
}
