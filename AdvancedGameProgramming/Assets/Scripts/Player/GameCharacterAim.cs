using NaughtyAttributes;
using UnityEngine;

public class GameCharacterAim : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("Camera being used to see the character")]
    private Camera mainCamera;

    [Foldout("Script Dependancies")]
    [SerializeField] [Tooltip("The object to rotate")]
    private Transform target;

    private LayerMask floorLayerMask; // Layer mask to only care about the floor

    private void Start()
    {
        floorLayerMask = LayerMask.GetMask("Floor");
    }
    private void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f, floorLayerMask))
        {
            Vector3 spinToPoint = hitInfo.point;
            spinToPoint.y = target.position.y;
            target.transform.LookAt(spinToPoint);
        }
    }
}
