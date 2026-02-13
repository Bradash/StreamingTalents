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

        if (GameManager.currentday == 1)
        {
            //Pre day stats
            GameManager.lastHighestviewers = 100;
            GameManager.lastAvargeChatMood = 0;
            GameManager.lastIncome = 0;
            GameManager.lastBalance = 0;
            GameManager.lastTodayQuota = 0;
        }

        //Make the stats
        HighestViewers = GameManager.highestviewers;
        AverageChatMood = GameManager.avargeChatMood;
        TodaysIncome = GameManager.endOfDayMoney - GameManager.endOfDayMoney;
        Quota = GameManager.todayQuota;
        YesterdaysBalance = GameManager.lastBalance;
        GameManager.currentmoney -= GameManager.todayQuota;
        CurrentBalance = GameManager.currentmoney;

        //Put them on the text
        print(HighestViewers);
        print(AverageChatMood);
        print(TodaysIncome);
        print(Quota);
        print(YesterdaysBalance);
        print(CurrentBalance);



        //Make the last stats

        GameManager.lastHighestviewers = HighestViewers;
        GameManager.lastAvargeChatMood = AverageChatMood;
        //GameManager.lastIncome = EndOfDayMoney;
        //GameManager.lastBalance = StartOfDayMoney;
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
