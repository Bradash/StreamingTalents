using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
        TodaysIncome = GameManager.endOfDayMoney - GameManager.startOfDayMoney;
        Quota = GameManager.todayQuota;
        YesterdaysBalance = GameManager.lastBalance;
        GameManager.currentmoney -= GameManager.todayQuota;
        CurrentBalance = GameManager.currentmoney;
        HighestViewersChange = HighestViewers - GameManager.lastHighestviewers;
        AverageChatMoodChange = AverageChatMood - GameManager.lastAvargeChatMood;
        TodayIncomeChange = TodaysIncome - GameManager.lastIncome;
        QuotaChange = Quota - GameManager.lastTodayQuota;


        //Put them on the text
        print(HighestViewers);
        print(AverageChatMood);
        print(TodaysIncome);
        print(Quota);
        print(YesterdaysBalance);
        print(CurrentBalance);
        print(HighestViewersChange);
        print(AverageChatMoodChange);
        print(TodayIncomeChange);
        print(QuotaChange);

        Stats.text = "\n" + Mathf.FloorToInt(HighestViewers) + "\n" + Mathf.FloorToInt(AverageChatMood) + "\n" + Mathf.FloorToInt(TodaysIncome) + "\n" + Mathf.FloorToInt(Quota) + "\n" + Mathf.FloorToInt(YesterdaysBalance) + "\n" + Mathf.FloorToInt(CurrentBalance);
        Changes.text = "Changes from Yesterday" + "\n" + Mathf.FloorToInt(HighestViewersChange) + "\n" + Mathf.FloorToInt(AverageChatMoodChange) + "\n" + Mathf.FloorToInt(TodayIncomeChange) + "\n" + Mathf.FloorToInt(QuotaChange);

        //Make the last stats

        GameManager.lastHighestviewers = HighestViewers;
        GameManager.lastAvargeChatMood = AverageChatMood;
        GameManager.lastIncome = TodaysIncome;
        GameManager.lastBalance = CurrentBalance;
        GameManager.lastTodayQuota = Quota;


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
