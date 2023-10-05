using UnityEngine;

public class AttackDamageUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int baseDamageToAdd = 1;

    private int upgradeID = 8;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        PlayerStatsManager playerStatsManager = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        playerStatsManager.BaseDamage = baseDamageToAdd;
    }

    public void IncreaseNumber(int amountToAdd)
    {
        baseDamageToAdd += amountToAdd;
    }
}
