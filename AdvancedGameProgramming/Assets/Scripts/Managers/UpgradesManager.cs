using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{

    [SerializeField]
    private List<UpgradeBase> upgradeScriptableObjects;

    public List<UpgradeBase> UpgradeScriptableObjects { get { return upgradeScriptableObjects; } }
}
