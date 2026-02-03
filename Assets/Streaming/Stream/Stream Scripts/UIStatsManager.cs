using TMPro;
using UnityEngine;

public class UIStatsManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text goalText;
    public TMP_Text ViewersText;
    public TMP_Text HappinessText;

    float money;
    float goal;
    float viewers;
    float happiness;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (1 == 1)//Day check later
        {
            money = 17;
            goal = 120;
            viewers = 246;
            happiness = 36;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + money;
        goalText.text = "Goal:  $" + goal;
        ViewersText.text = "Viewers: " + viewers;
        HappinessText.text = "Happiness: " + happiness + "%";
    }
}
