using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StreamResults : MonoBehaviour
{
    public TextMeshProUGUI Stats;
    public TextMeshProUGUI Changes;
    public TextMeshProUGUI exitButton;

    float HighestViewers;
    float AverageChatMood;
    float TodaysIncome;
    float Quota;
    float YesterdaysBalance;
    float CurrentBalance;

    float HighestViewersChange;
    float AverageChatMoodChange;
    float TodayIncomeChange;
    float QuotaChange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Testing
        GameManager.currentday = 3;

        if (GameManager.currentday == 1)
        {
            //Pre day stats
            GameManager.lastHighestviewers = 100;
            GameManager.lastAvargeChatMood = 0;
            GameManager.lastEndOfDayMoney = 0;
            GameManager.lastStartOfDayMoney = 0;
            GameManager.lastTodayQuota = 0;
        }

        //Make the stats



        //Put them on the text
        print(GameManager.highestviewers);
        print(GameManager.avargeChatMood);


        //Make the last stats

        GameManager.lastHighestviewers = HighestViewers;
        GameManager.lastAvargeChatMood = AverageChatMood;
        //GameManager.lastEndOfDayMoney = EndOfDayMoney;
        //GameManager.lastStartOfDayMoney = StartOfDayMoney;
        //GameManager.lastTodayQuota = TodayQuota;


        //Check for end
        if (GameManager.currentday == 3)
        {
            exitButton.text = "End Demo";
        }
        else
        {
            exitButton.text = "End Day";
        }
    }
}
