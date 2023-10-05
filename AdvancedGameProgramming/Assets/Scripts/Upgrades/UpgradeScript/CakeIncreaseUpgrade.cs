using UnityEngine;

public class CakeIncreaseUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private float cakeSizeToIncrease = 0.2f;

    private int upgradeID = 7;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        CakeController cakeController = GameObject.Find("PlayerController").GetComponent<CakeController>();
        cakeController.IncreaseCakeSize(cakeSizeToIncrease);
    }

    public void IncreaseNumber(float amountToAdd)
    {
        cakeSizeToIncrease += amountToAdd;
    }
}
