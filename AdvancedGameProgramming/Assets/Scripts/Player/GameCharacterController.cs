using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class GameCharacterController : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Script SysPlayerInput to pull movement inputs from")]
    private SysPlayerInput playerInput;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("The rigidbody attached to the character")]
    private Rigidbody rigidbody3D;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Orientation of the body")]
    public Transform orientation;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("How fast the player should move")]
    private float moveSpeed = 6f;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("The jump force of the player")]
    private float jumpForce = 500f;

    [Foldout("Player specs")]
    [SerializeField] [Tooltip("Max velocities in each direction")]
    private Vector3 maxVelocities;
    
    private Vector3 moveDirection;

    public float maxYSpeed { set { maxVelocities.y = value; } }

    private bool isGrounded = true;

    public void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.5f);

        SpeedControl();
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    public void Jump()
    {
        if (isGrounded)
            rigidbody3D.AddForce(transform.up * jumpForce);
    }

    private void SpeedControl()
    {
        // limiting speed on ground or in air
        Vector3 flatVel = new Vector3(rigidbody3D.velocity.x, 0f, rigidbody3D.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rigidbody3D.velocity = new Vector3(limitedVel.x, rigidbody3D.velocity.y, limitedVel.z);
        }

        // limit y vel
        if (maxVelocities.y != 0 && rigidbody3D.velocity.y > maxVelocities.y)
            rigidbody3D.velocity = new Vector3(rigidbody3D.velocity.x, maxVelocities.y, rigidbody3D.velocity.z);
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = playerInput.Direction * moveSpeed;

        // on ground
        if (isGrounded)
            rigidbody3D.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
