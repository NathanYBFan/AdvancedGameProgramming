using UnityEngine;

public class AreaDamage : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private Vector3 increaseSizeAmount = new Vector3(1, 0, 1);

    private int upgradeID = 5;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        AreaDamageController areaDamageController = GameObject.Find("AreaDamage").GetComponent<AreaDamageController>();
        areaDamageController.IncreaseBoxSize(increaseSizeAmount);
    }

    public void IncreaseNumber(Vector3 amountToAdd)
    {
        amountToAdd.y = 0f;
        increaseSizeAmount += amountToAdd;
    }
}
