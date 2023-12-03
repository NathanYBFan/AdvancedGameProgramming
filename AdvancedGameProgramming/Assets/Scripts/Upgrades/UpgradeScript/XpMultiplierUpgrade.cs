using UnityEngine;

public class XpMultiplierUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int xpMultiplierToAdd = 1;

    private int upgradeID = 3;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterStats._Instance.SetXpMultiplayer(GameCharacterStats._Instance.XpMultiplier + xpMultiplierToAdd);
    }

    public void IncreaseNumber(int amountToAdd)
    {
        xpMultiplierToAdd += amountToAdd;
    }
}
