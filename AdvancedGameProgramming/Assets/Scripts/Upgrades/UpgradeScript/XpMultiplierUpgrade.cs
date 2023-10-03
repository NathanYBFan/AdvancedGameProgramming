using UnityEngine;

public class XpMultiplierUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int xpMultiplierToAdd = 1;

    private int upgradeID = 3;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterStats gameCharacterStats = GameObject.Find("PlayerController").GetComponent<GameCharacterStats>();
        gameCharacterStats.SetXpMultiplayer(gameCharacterStats.XpMultiplier + xpMultiplierToAdd);
    }

    public void IncreaseNumber(int amountToAdd)
    {
        xpMultiplierToAdd += amountToAdd;
    }
}
