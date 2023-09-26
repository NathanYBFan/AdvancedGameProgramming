using NaughtyAttributes;
using UnityEngine;

public class GameCharacterController : MonoBehaviour
{
    [SerializeField] [Required]     // Player input
    private SysPlayerInput playerInput;

    [SerializeField] [Required]		// Player Rigidbody
    private Rigidbody rigidbody3D;
    public Rigidbody Rigidbody3D { get {  return rigidbody3D; } }


    [SerializeField]                // Move speed of player
    private float moveSpeed = 6f;

    [SerializeField]                // Jump force of player
    private float jumpForce = 500f;

    public void FixedUpdate()
    {
        Vector3 direction = playerInput.Direction * moveSpeed;
        direction.y = rigidbody3D.velocity.y;
        if (direction.magnitude >= 0.1f)
            rigidbody3D.velocity = transform.forward + direction;
    }

    public void Jump()
    {
        rigidbody3D.AddForce(transform.up * jumpForce);
    }
}
