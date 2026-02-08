using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class UIStatsManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text goalText;
    public TMP_Text ViewersText;
    public TMP_Text moodText;

    float money;
    float goal;
    float viewers;
    float mood;


    public static UIStatsManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        if (1 == 1)//Day check later
        {
            money = 0;
            goal = 100;
            viewers = 100;
            mood = 10;
        }
    }

    public void AddMoney(float change)
    {
        money += change;
    }

    public void AddMood(float change)
    {
        mood += change;
    }

    public void AddViewers(float change)
    {
        viewers += change;
    }


    // Update is called once per frame
    void Update()
    {
        //Natural decay

        mood -= 0.1f * Time.deltaTime;
        viewers -= 1f * Time.deltaTime;

        //Checks

        if (viewers < 0)
        {
            viewers = 0;
        }
        if (mood < 0)
        {
            mood = 0;
        }
        if (mood > 99.9)
        {
            mood = 99.9f;
        }


        moneyText.text = "Money: $" + Mathf.FloorToInt(money);
        goalText.text = "Goal:  $" + Mathf.FloorToInt(goal);
        ViewersText.text = "Viewers: " + Mathf.FloorToInt(viewers);
        moodText.text = "Viewer Mood: " + Mathf.FloorToInt(mood) + "%";

    }
}
