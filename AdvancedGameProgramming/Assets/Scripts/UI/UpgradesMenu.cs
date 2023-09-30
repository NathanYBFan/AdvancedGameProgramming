using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMenu : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Upgrade Options available to the player as a list")]
    private List<GameObject> upgrades;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Location to spawn the transform object")]
    private Transform upgradeParentTransform;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Prefab to spawn when needed")]
    private GameObject upgradePrefab;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("number of Options currenty available")]
    private int numberOfUpgradeOptions = 2;

    private int maxNumberOfUpgradeOptions = 5;

    private void Awake()
    {
        UpdateUpgradeOptions();
    }

    public void RollForPowerups()
    {
        if (upgrades == null) return;

        foreach (var upgrade in upgrades)
        {
            Powerups powerup = (Powerups) Random.Range(0, 1); // Replace 1 with the number of powerups
            // Get necessary assignments in each upgrade: Image, Button Name, Button assignment
        }
    }
    
    public void AddUpgradeOptions(int numberOfUpgradeOptionsToAdd)
    {
        numberOfUpgradeOptions += numberOfUpgradeOptionsToAdd;

        if (numberOfUpgradeOptions > maxNumberOfUpgradeOptions)
            numberOfUpgradeOptions = maxNumberOfUpgradeOptions;

        else if (numberOfUpgradeOptions < 0)
            numberOfUpgradeOptions = 0;

        UpdateUpgradeOptions();
    }


    private void UpdateUpgradeOptions()
    {
        if (upgrades.Count == numberOfUpgradeOptions) return;

        else if (upgrades.Count < numberOfUpgradeOptions) // Need to increase number of options
        {
            for (int i = 0; i < (numberOfUpgradeOptions - upgrades.Count); i++)
            {
                upgrades.Add(GameObject.Instantiate(upgradePrefab, upgradeParentTransform));
                numberOfUpgradeOptions++;
            }
        }
        
        else if (upgrades.Count > numberOfUpgradeOptions) // Need to decrase number of options
        {
            for (int i = 0; i < (upgrades.Count - numberOfUpgradeOptions); i++)
            {
                upgrades.RemoveAt(0);
                numberOfUpgradeOptions--;
            }
        }
    }


    public void CloseMenu()
    {
        this.gameObject.SetActive(false);
    }

    public enum Powerups
    {
        AttackSize,
        AttackSpeed,
        MoveSpeed,
        MaxHealth,
        HpRegen,
        XPGain,
        BaseDamage,
        None
    }
}
