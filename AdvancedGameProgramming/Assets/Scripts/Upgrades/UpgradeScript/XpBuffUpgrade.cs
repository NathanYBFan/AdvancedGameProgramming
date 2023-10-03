using UnityEngine;

public class XpBuffUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int xpBuffToAdd = 1;

    private int upgradeID = 2;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterStats gameCharacterStats = GameObject.Find("PlayerController").GetComponent<GameCharacterStats>();
        gameCharacterStats.AddXpBuff(xpBuffToAdd);
    }

    public void IncreaseNumber(int amountToAdd)
    {
        xpBuffToAdd += amountToAdd;
    }
}
