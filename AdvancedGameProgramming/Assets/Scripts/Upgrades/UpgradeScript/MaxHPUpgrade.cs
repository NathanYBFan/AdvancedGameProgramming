using UnityEngine;

public class MaxHPUpgrade : MonoBehaviour, UpgradeInterface 
{
    [SerializeField]
    private int maxHPToAdd = 1;

    private int upgradeID = 1;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterStats gameCharacterStats = GameObject.Find("PlayerController").GetComponent<GameCharacterStats>();
        gameCharacterStats.AddMaxHP(maxHPToAdd);
    }

    public void IncreaseNumber(int amountToAdd)
    {
        maxHPToAdd += amountToAdd;
    }
}
