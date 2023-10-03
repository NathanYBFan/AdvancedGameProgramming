using UnityEngine;

public class IncreaseUpgradeOptionsUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int upgradeOptionsToAdd = 1;

    private int upgradeID = 4;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        UpgradesMenu upgradesMenu = GameObject.Find("UpgradesMenu").GetComponent<UpgradesMenu>();
        upgradesMenu.AddUpgradeOptions(upgradeOptionsToAdd);
    }

    public void IncreaseNumber( int amountToAdd )
    {
        upgradeOptionsToAdd += amountToAdd;
    }
}
