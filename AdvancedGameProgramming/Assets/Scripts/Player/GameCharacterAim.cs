using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterAim : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform target;

    private void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            Vector3 spinToPoint = hitInfo.point;
            spinToPoint.y = target.position.y;
            target.transform.LookAt(spinToPoint);
        }
    }
}
