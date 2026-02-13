using System.Threading;
using TMPro;
using Unity.XR.GoogleVr;
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
    public int collab;
    public int game;

    float highestviewers;
    float maxMood;
    float numberMood;

    int currentday;

    float time = 20;


    public static UIStatsManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        collab = GameManager.SelectedCollab;
        print(GameManager.SelectedCollab);
        game = GameManager.SelectedMinigame;

        float highestviewers = 0;
        float maxMood = 0;
        float numberMood = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        currentday = GameManager.currentday;
        print("Day:" + GameManager.currentday);

        //Testing
        currentday = 1;

        if (currentday == 1)
        {
            money = 0;
            goal = 30;
            viewers = 100;
            mood = 70;
            points = 100;
            time = 150;
            //collab = 2;
            //game = 0;
        }
        if (currentday == 2)
        {
            goal = 100;
            viewers = 200;
            mood = 50;
            points = 50;
            time = 240;
        }
        if (currentday == 3)
        {
            goal = 200;
            viewers = 250;
            mood = 60;
            points = 50;
            time = 300;
        }

        GameManager.startOfDayMoney = money;
        GameManager.todayQuota = goal;

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
        if (highestviewers < viewers)
        {
            highestviewers = viewers;
        }
        maxMood += mood;
        numberMood += 1;


        //Natural decay

        viewers += ((0.2f * mood) - 10) * Time.deltaTime;
        mood -= (0.1f+(0.2f-(points/500))) * Time.deltaTime;
        time -= Time.deltaTime;

        //Point decay depends on minigame

        if (game == 0)
        {
            points -= 0 * Time.deltaTime;
        }
        if (game == 1)
        {
            points -= 10f * Time.deltaTime;
        }
        if (game == 2)
        {
            points -= 2f * Time.deltaTime;
        }

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
            GameManager.highestviewers = highestviewers;
            GameManager.avargeChatMood = maxMood / numberMood;
            GameManager.endOfDayMoney = money;
            //transition to next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }


        moneyText.text = "Money: $" + Mathf.FloorToInt(money);
        goalText.text = "Goal:  $" + Mathf.FloorToInt(goal);
        ViewersText.text = "Viewers: " + Mathf.FloorToInt(viewers);
        moodText.text = "Viewer Mood: " + Mathf.FloorToInt(mood) + "%";
        timeText.text = "Time left: " + Mathf.FloorToInt(time);

        //Debug.Log("Points: " + points);
    }
}
