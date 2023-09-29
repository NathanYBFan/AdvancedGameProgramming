using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class GameCharacterDash : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("Character Controller to set and get values from player")]
    private GameCharacterController characterController;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("The rigidbody attached to the character")]
    private Rigidbody rigidbody3D;

    [Foldout("Script Dependancies")]
    [SerializeField] [Required] [Tooltip("The rigidbody attached to the character")]
    private GameObject dashTrail;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("The dash force of the player")]
    private float dashForce = 500f;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Max y dash speed")]
    private float maxDashYSpeed;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("Upwards dash force")]
    private float dashUpwardsForce;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long for the dash to last")]
    private float dashDuration;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("How long before the next dash is off cooldown")]
    private float dashCoolDown;

    private bool canDash = true;

    private Vector3 delayedForceToApply;

    public void AttemptDash()
    {
        if (!canDash)
            return;
        else
        {
            Dash();
            StartCoroutine(DashCooldown());
        }
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

    private void Dash()
    {
        canDash = false;

        //Not turning to face correct direction
        Vector3 newPos = transform.position;
        newPos.y += 1f;
        GameObject.Instantiate(dashTrail, newPos, rigidbody3D.transform.rotation);

        characterController.maxYSpeed = maxDashYSpeed;

        Vector3 direction = characterController.orientation.forward;

        Vector3 forceToApply = direction * dashForce + transform.up * dashUpwardsForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void DelayedDashForce()
    {
        rigidbody3D.velocity = Vector3.zero;

        rigidbody3D.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        characterController.maxYSpeed = 0;
    }
}
