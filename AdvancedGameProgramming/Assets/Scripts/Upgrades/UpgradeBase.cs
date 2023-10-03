using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Base", menuName = "ScriptableObjects/UpgradeBase")]
[Serializable]
public class UpgradeBase : ScriptableObject
{
    [SerializeField]
    public int upgradeID = 0;
    
    [SerializeField]
    public string upgradeName = null;

    [SerializeField]
    public string upgradeDescription = null;

    [SerializeField]
    public Sprite upgradeImage = null;

    [SerializeField]
    public GameObject upgradePrefab = null;
}
