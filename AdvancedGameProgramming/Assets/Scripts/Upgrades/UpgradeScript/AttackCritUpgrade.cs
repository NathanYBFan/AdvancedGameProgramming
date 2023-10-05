using UnityEngine;

public class AttackCritUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int critChanceToAdd = 1;

    private int upgradeID = 9;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        PlayerStatsManager playerStatsManager = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        playerStatsManager.CritChance = critChanceToAdd;
    }

    public void IncreaseNumber(int amountToAdd)
    {
        critChanceToAdd += amountToAdd;
    }
}
