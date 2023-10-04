using UnityEngine;

public class AttackSizeUpgrade : MonoBehaviour, UpgradeInterface
{
    [SerializeField]
    private float attackSizeToAdd = 0.2f;

    private int upgradeID = 6;
    int UpgradeInterface.upgradeID { get { return upgradeID; } }

    public void Run()
    {
        GameCharacterAttackManager gameCharacterAttackManager = GameObject.Find("PlayerController").GetComponent<GameCharacterAttackManager>();
        gameCharacterAttackManager.IncreaseScale(attackSizeToAdd);
    }

    public void IncreaseNumber(float amountToAdd)
    {
        attackSizeToAdd += amountToAdd;
    }
}
