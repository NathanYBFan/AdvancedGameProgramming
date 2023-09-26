using NaughtyAttributes;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Target to follow")]
    private Transform target;
    
    [Foldout("Camera Specs")]
    [SerializeField] [Tooltip("Offset for the camera to be at (From the target)")]
    Vector3 Offset = Vector3.zero;

    [Foldout("Camera Specs")]
    [SerializeField] [ReadOnly] [Tooltip("List of obstructions currently infront of the player")] 
    private Transform[] obstructions;

    [Foldout("Camera Specs")]
    [SerializeField] [Range(0, 1)] [Tooltip("How much delay before the camera catches up with the player")]
    private float movementSmoothing = 0.25f;

    private int numbOfOldHits = 0;      // Number of hidden objects
    private Vector3 currentVelocity;    // Current move speed of the camera

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + Offset, ref currentVelocity, movementSmoothing);
        transform.LookAt(target);
        ViewObstructed();
    }

    private void ViewObstructed()
    {
        float distFromTarget = Vector3.Distance(transform.position, target.transform.position);
        
        int layerNumber = LayerMask.NameToLayer("Walls");
        int layerMask = 1 << layerNumber;
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position, target.position - transform.position, distFromTarget, layerMask);
        
        if (hits.Length > 0)
        {
            // Means that some stuff is blocking the view
            int newHits = hits.Length - numbOfOldHits;

            if (obstructions != null && obstructions.Length > 0 && newHits < 0)
            {
                // Repaint all the previous obstructions. Because some of the stuff might be not blocking anymore
                for (int i = 0; i < obstructions.Length; i++)
                {
                    obstructions[i].gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
            obstructions = new Transform[hits.Length];
            // Hide the current obstructions
            for (int i = 0; i < hits.Length; i++)
            {
                Transform obstruction = hits[i].transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                obstructions[i] = obstruction;
            }
            numbOfOldHits = hits.Length;
        }
        else
        {
            // Mean that no more stuff is blocking the view and sometimes all the stuff is not blocking as the same time
            if (obstructions != null && obstructions.Length > 0)
            {
                for (int i = 0; i < obstructions.Length; i++)
                {
                    obstructions[i].gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
                numbOfOldHits = 0;
                obstructions = null;
            }
        }
    }
}
