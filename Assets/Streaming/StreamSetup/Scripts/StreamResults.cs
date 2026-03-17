using System.Linq;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StreamResults : MonoBehaviour
{
    public TextMeshProUGUI Stats1;
    public TextMeshProUGUI Stats2;
    public TextMeshProUGUI Stats3;
    public TextMeshProUGUI Stats4;
    public TextMeshProUGUI Stats5;
    public TextMeshProUGUI Stats6;

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

    public tutorialManager tutorialManage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        tutorialManage.playTutorial("Stream Results", GameManager.tutorialList["Stream Results"].Keys.First(), 10f, true);
    }

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

        //Change the color
        if (HighestViewersChange <= 0)
        {
            if (HighestViewersChange == 0)
            {
                Stats1.color = Color.white;
            }
            else
            {
                Stats1.color = Color.red;
            }
        }
        else
        {
            Stats1.color = Color.green;
        }

        if (AverageChatMoodChange <= 0)
        {
            if (AverageChatMoodChange == 0)
            {
                Stats2.color = Color.white;
            }
            else
            {
                Stats2.color = Color.red;
            }
        }
        else
        {
            Stats2.color = Color.green;
        }

        if (TodayIncomeChange <= 0)
        {
            if (TodayIncomeChange == 0)
            {
                Stats3.color = Color.white;
            }
            else
            {
                Stats3.color = Color.red;
            }
        }
        else
        {
            Stats3.color = Color.green;
        }

        if (YesterdaysBalance <= 0)
        {
            if (YesterdaysBalance == 0)
            {
                Stats5.color = Color.white;
            }
            else
            {
                Stats5.color = Color.red;
            }
        }
        else
        {
            Stats5.color = Color.green;
        }

        if (CurrentBalance <= 0)
        {
            if (CurrentBalance == 0)
            {
                Stats6.color = Color.white;
            }
            else
            {
                Stats6.color = Color.red;
            }
        }
        else
        {
            Stats6.color = Color.green;
        }



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

        //Text
        Stats1.text = "Highest Viewers: \t    " + Mathf.FloorToInt(HighestViewers) + "\t        " + Mathf.FloorToInt(HighestViewersChange);
        Stats2.text = "Average Chat Mood:\t    " + Mathf.FloorToInt(AverageChatMood) + "\t        " + Mathf.FloorToInt(AverageChatMoodChange);
        Stats3.text = "Today's Income: \t    " + Mathf.FloorToInt(TodaysIncome) + "\t        " + Mathf.FloorToInt(TodayIncomeChange);
        Stats4.text = "Quota: \t\t    " + Mathf.FloorToInt(Quota) + "\t        " + Mathf.FloorToInt(QuotaChange);

        Stats5.text = "Yesterday's Balance:\n" + Mathf.FloorToInt(YesterdaysBalance);
        Stats6.text = "Current Balance:\n" + Mathf.FloorToInt(CurrentBalance);

        //Stats.text = "\n" + Mathf.FloorToInt(HighestViewers) + "\n" + Mathf.FloorToInt(AverageChatMood) + "\n" + Mathf.FloorToInt(TodaysIncome) + "\n" + Mathf.FloorToInt(Quota) + "\n" + Mathf.FloorToInt(YesterdaysBalance) + "\n" + Mathf.FloorToInt(CurrentBalance);
        //Changes.text = "Changes from Yesterday" + "\n" + Mathf.FloorToInt(HighestViewersChange) + "\n" + Mathf.FloorToInt(AverageChatMoodChange) + "\n" + Mathf.FloorToInt(TodayIncomeChange) + "\n" + Mathf.FloorToInt(QuotaChange);

        //Make the last stats

        GameManager.lastHighestviewers = HighestViewers;
        GameManager.lastAvargeChatMood = AverageChatMood;
        GameManager.lastIncome = TodaysIncome;
        GameManager.lastBalance = CurrentBalance;
        GameManager.lastTodayQuota = Quota;


        //Check for end
        /*if (GameManager.currentday == 3)
        {
            exitButton.text = "End Demo";
        }
        else
        {
            exitButton.text = "End Day";
        }*/
    }
}
