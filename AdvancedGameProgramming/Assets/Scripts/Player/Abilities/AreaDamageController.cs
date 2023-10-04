using System.Collections;
using UnityEngine;

public class AreaDamageController : MonoBehaviour
{
    [SerializeField]
    private Vector3 baseSize = new Vector3(5f, 0f, 5f);

    [SerializeField]
    private Transform areaObject;
    public Transform AreaObject { get { return areaObject; } }

    public void IncreaseBoxSize(Vector3 newSize) // lerp from base to new
    {
        if (areaObject.localScale.x < 5f) newSize = baseSize;
        StartCoroutine(scaleUpCoroutine(areaObject.localScale + newSize));
    }

    private IEnumerator scaleUpCoroutine(Vector3 newSize)
    {
        while (areaObject.localScale != newSize)
        {
            areaObject.localScale = Vector3.Lerp(areaObject.localScale, newSize, Time.deltaTime * 10);
            yield return new WaitForEndOfFrame();
        }
    }
}
