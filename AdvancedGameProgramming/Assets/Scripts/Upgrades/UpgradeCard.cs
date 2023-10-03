using NaughtyAttributes;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] [ReadOnly]
    private UpgradeBase upgradeBase;

    [SerializeField]
    private TextMeshProUGUI upgradeName;

    [SerializeField]
    private TextMeshProUGUI upgradeDescription;

    [SerializeField]
    private Image upgradeImage;

    public UpgradeBase UpgradeBase { get { return upgradeBase; } set { upgradeBase = value; } }

    public void Start()
    {
        ConfigureSO();
    }

    public void ClickedButton()
    {
        upgradeBase.upgradePrefab.GetComponent<UpgradeInterface>().Run();
        Time.timeScale = 1.0f;
        GameObject.Find("UpgradesMenu").SetActive(false);
    }

    public void ConfigureSO()
    {
        upgradeName.text = upgradeBase.upgradeName;
        upgradeDescription.text = upgradeBase.upgradeDescription;
        upgradeImage.sprite = upgradeBase.upgradeImage;
    }
}
