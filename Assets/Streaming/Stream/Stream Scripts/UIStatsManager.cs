using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class UIStatsManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text goalText;
    public TMP_Text ViewersText;
    public TMP_Text moodText;
    public TMP_Text timeText;

    public float money;
    public float goal;
    public float viewers;
    public float mood;
    public float points;

    int currentday;

    float time;
    float maxTime;


    public static UIStatsManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        //testing
        currentday = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        if (currentday == 1)//Day check later
        {
            money = 0;
            goal = 100;
            viewers = 100;
            mood = 50;
            points = 100;
            maxTime = 80;
            time = 80;
        }
        if (currentday == 2)//Day check later
        {
            goal = 200;
            viewers = 200;
            mood = 50;
            points = 100;
            maxTime = 300;
            time = 300;
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

        viewers += ((0.2f * mood) - 10) * Time.deltaTime;
        mood -= (0.1f+(0.2f-(points/500))) * Time.deltaTime;
        points -= 2f * Time.deltaTime;
        time -= Time.deltaTime;

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
        if (points < 0)
        {
            points = 0;
        }
        if (points > 100)
        {
            points = 100;
        }
        if (time < 0)
        {
            time = 0;
            print("End scene");
            //transition to next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


        moneyText.text = "Money: $" + Mathf.FloorToInt(money);
        goalText.text = "Goal:  $" + Mathf.FloorToInt(goal);
        ViewersText.text = "Viewers: " + Mathf.FloorToInt(viewers);
        moodText.text = "Viewer Mood: " + Mathf.FloorToInt(mood) + "%";
        timeText.text = "Time left: " + Mathf.FloorToInt(time);

    }
}
