using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public TextMeshProUGUI optionText;

    TextingOption myOption;

    public void Setup(TextingOption option)
    {
        myOption = option;
        optionText.text = option.optionText;
    }

    public void OnClicked()
    {
        // Apply relationship changes
        GameManager.wolfRelationship += myOption.WolfRelationChange;
        GameManager.unicornRelationship += myOption.UnicornRelationChange;
        GameManager.dragonRelationship += myOption.DragonRelationChange;
        Debug.Log(GameManager.wolfRelationship);

        // Destroy all option buttons
        TextSpawner.Instance.ClearOptions();
        TextSpawner.Instance.StartConversation(myOption.nextMessage);
    }
}