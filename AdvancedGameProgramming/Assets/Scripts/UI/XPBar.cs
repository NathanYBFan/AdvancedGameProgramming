using NaughtyAttributes;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("")]
    private GameCharacterStats playerXpStats;

    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Textfield that displays the number")]
    private TextMeshProUGUI displayText;
    
    [Foldout("Script Dependencies")]
    [SerializeField] [Tooltip("Slider Bar to display amount of XP")]
    private Slider guiBar;

    public void Start()
    {
        RenderNewText();
    }

    public void RenderNewText()
    {
        string textToDisplay = "XP: " + playerXpStats.Xp + " / " + playerXpStats.MaxXP;
        displayText.text = textToDisplay;

        float barFillAmount = playerXpStats.Xp / playerXpStats.MaxXP;
        guiBar.value = barFillAmount;
    }
}
