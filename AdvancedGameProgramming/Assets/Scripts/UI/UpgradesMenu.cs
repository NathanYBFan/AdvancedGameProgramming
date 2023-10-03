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

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("What upgrades are avilable to pick")]
    private List<UpgradeBase> upgradeOptions;

    [Foldout("Specs")]
    [SerializeField] [Tooltip("number of Options currenty available")]
    private int numberOfUpgradeOptions = 2;

    private int maxNumberOfUpgradeOptions = 5;

    private void Awake()
    {
        Time.timeScale = 0f;
        UpdateUpgradeOptions();
        RollForPowerups();
    }
    
    public void RollForPowerups()
    {
        if (upgrades == null) return;

        foreach (var upgrade in upgrades)
        {
            int upgradeToShow = Random.Range(0, upgradeOptions.Count); // Replace 1 with the number of powerups
            UpgradeCard upgradeCard = upgrade.GetComponent<UpgradeCard>();
            upgradeCard.UpgradeBase = upgradeOptions[upgradeToShow];
            upgradeCard.ConfigureSO();
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
        Time.timeScale = 1f;
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
