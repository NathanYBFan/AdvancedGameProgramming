using UnityEngine;

public class CakeController : MonoBehaviour
{
    [SerializeField]
    GameObject[] cakes = new GameObject[2];

    public void IncreaseCakeSize(float sizeToIncreaseBy)
    {
        Vector3 newSize = cakes[0].transform.localScale;
        newSize.x += sizeToIncreaseBy;
        newSize.y += sizeToIncreaseBy;
        newSize.z += sizeToIncreaseBy;

        foreach (var cake in cakes)
            cake.transform.localScale = newSize;
    }
}
