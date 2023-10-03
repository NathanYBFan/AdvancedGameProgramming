using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    private int numberofUpgrades;
    public int NumberOfUpgrades { get; private set; }

    [SerializeField]
    private List<ScriptableObject> scriptableObjects;

    public UpgradeInterface GetUpgradeInterface(string nameOfScript)
    {
        return gameObject.GetComponent<UpgradeInterface>();
    }
}
