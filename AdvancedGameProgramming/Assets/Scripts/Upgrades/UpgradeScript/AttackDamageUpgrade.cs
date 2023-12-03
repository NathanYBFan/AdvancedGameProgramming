using UnityEngine;

public class AttackDamageUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private int baseDamageToAdd = 1;

    private int upgradeID = 8;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterStats._Instance.BaseDamage += baseDamageToAdd;
    }

    public void IncreaseNumber(int amountToAdd)
    {
        baseDamageToAdd += amountToAdd;
    }
}
