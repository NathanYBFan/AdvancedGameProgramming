using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMenu : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Upgrade Manager to get upgrade options")]
    private UpgradesManager upgradeManager;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Upgrade Options available to the player as a list")]
    private List<GameObject> upgrades;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Location to spawn the transform object")]
    private Transform upgradeParentTransform;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Prefab to spawn when needed")]
    private GameObject upgradePrefab;

    
    private int maxNumberOfUpgradeOptions = 5;

    public void OnEnable()
    {
        UpdateAllUpgradeOptions();
    }

    public void ReRollAllPowerups()
    {
        if (upgrades == null) return;

        foreach (var upgrade in upgrades)
        {
            int upgradeToShow = Random.Range(0, upgradeManager.UpgradeScriptableObjects.Count); // Replace 1 with the number of powerups
            UpgradeCard upgradeCard = upgrade.GetComponent<UpgradeCard>();
            upgradeCard.UpgradeBase = upgradeManager.UpgradeScriptableObjects[upgradeToShow];
            upgradeCard.ConfigureSO();
        }
    }
    
    public void AddUpgradeOptions(int numberOfUpgradeOptionsToAdd)
    {

        GameCharacterStats._Instance.UpgradeOptions += numberOfUpgradeOptionsToAdd;

        int numberOfUpgradeOptions = GameCharacterStats._Instance.UpgradeOptions;

        if (numberOfUpgradeOptions > maxNumberOfUpgradeOptions)
            numberOfUpgradeOptions = maxNumberOfUpgradeOptions;

        else if (numberOfUpgradeOptions < 0)
            numberOfUpgradeOptions = 0;

        if (numberOfUpgradeOptions == maxNumberOfUpgradeOptions)
        {
            for (int i = 0; i < upgradeManager.UpgradeScriptableObjects.Count; i++)
            {
                if (upgradeManager.UpgradeScriptableObjects[i].name == "IncreaseUpgradeOptions")
                {
                    upgradeManager.UpgradeScriptableObjects.RemoveAt(i);
                    return;
                }
            }
        }

        UpdateAllUpgradeOptions();
    }


    private void UpdateAllUpgradeOptions()
    {
        int numberOfUpgradeOptions = GameCharacterStats._Instance.UpgradeOptions;

        if (upgrades.Count == numberOfUpgradeOptions) return;

        else if (upgrades.Count < numberOfUpgradeOptions) // Need to increase number of options
        {
            for (int i = 0; i < (numberOfUpgradeOptions - upgrades.Count) + 1; i++)
                upgrades.Add(GameObject.Instantiate(upgradePrefab, upgradeParentTransform));
        }
        
        else if (upgrades.Count > numberOfUpgradeOptions) // Need to decrase number of options
        {
            for (int i = 0; i < (upgrades.Count - numberOfUpgradeOptions); i++)
            {
                Destroy(upgrades[0]);
                upgrades.RemoveAt(0);
            }
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        UpdateAllUpgradeOptions();
        ReRollAllPowerups();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
