using NaughtyAttributes;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
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
        string textToDisplay = "XP: " + GameCharacterStats._Instance.Xp + " / " + GameCharacterStats._Instance.MaxXP;
        displayText.text = textToDisplay;

        float barFillAmount = GameCharacterStats._Instance.Xp / GameCharacterStats._Instance.MaxXP;
        guiBar.value = barFillAmount;
    }
}
