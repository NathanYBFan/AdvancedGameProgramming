using UnityEngine;

public class CakeController : MonoBehaviour
{
    [SerializeField]
    GameObject[] cakes;


    private void OnEnable()
    {
        SetCakeSize(Vector3.one * GameCharacterStats._Instance.CakeSize);
    }

    public void IncreaseCakeSize(float sizeToIncreaseBy)
    {
        Vector3 newSize = cakes[0].transform.localScale;
        newSize.x += sizeToIncreaseBy;
        newSize.y += sizeToIncreaseBy;
        newSize.z += sizeToIncreaseBy;

        SetCakeSize(newSize);
    }
    private void SetCakeSize(Vector3 newSize)
    {
        foreach (var cake in cakes)
            cake.transform.localScale = newSize;
    }
}
