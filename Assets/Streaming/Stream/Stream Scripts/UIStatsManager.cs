using System.Threading;
using TMPro;
using Unity.XR.GoogleVr;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;


//This script runs before all others in the scene.
public class UIStatsManager : MonoBehaviour
{
    //Big change

    public TMP_Text moneyText;
    public TMP_Text goalText;
    public TMP_Text ViewersText;
    public TMP_Text moodText;
    public TMP_Text timeText;

    public GameObject QuitButton;
    public GameObject QuitMenu;

    public float money;
    public int goal;
    public float viewers;
    public float mood;
    public float points;
    public int collab;
    public int game;
    public int narrative;

    public RawImage moodPicture;
    public Texture sad;
    public Texture middle;
    public Texture happy;
    public RawImage clockPicture;
    public ParticleSystem coinParticles;

    float highestviewers;
    float maxMood;
    float numberMood;
    bool transitionStarted;

    int currentday;

    float time = 40;


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

        //Testing
        //GameManager.currentday = 7;
        //GameManager.SelectedCollab = 2;
        //GameManager.SelectedMinigame = 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        currentday = GameManager.currentday;
        print("Day:" + GameManager.currentday);
        QuitButton.SetActive(true);
        QuitMenu.SetActive(false);

        if (currentday > 0)
        {
            if (currentday >= 4)
            {
                if (currentday >= 7)
                {
                    narrative = 3;
                }
                else
                {
                    narrative = 2;
                }
            }
            else
            {
                narrative = 1;
            }
        }
        else
        {
            narrative = 0;
        }

        if (currentday == 99)
        {
            money = 0;
            goal = 100;
            viewers = 10000;
            mood = 100;
            points = 100;
            time = 20;
            collab = 2;
            game = 1;
        }
        if (currentday == 0)
        {
            money = 0;
            goal = 0;
            viewers = 50;
            mood = 100;
            points = 100;
            time = 60;
            //collab = 2;
            //game = 0;
        }
        if (currentday == 1)
        {
            money = 0;
            goal = 15;
            viewers = 100;
            mood = 70;
            points = 100;
            time = 60;
            //collab = 2;
            //game = 0;
        }
        if (currentday >1)
        {
            money = GameManager.currentmoney;
            goal = currentday*15;
            viewers = currentday*50+100;
            mood = 60;
            points = 75;
            time = (currentday+2)*20;
        }

        GameManager.startOfDayMoney = money;
        GameManager.todayQuota = goal;
        clockPicture.color = Color.white;
        transitionStarted = false;
    }

    public void AddMoney(float change)
    {
        money += change;
        var emission = coinParticles.emission;
        emission.SetBurst(0, new ParticleSystem.Burst(0, change));

        coinParticles.Play();
    }

    public void AddMood(float change)
    {
        mood += change;
    }

    public void AddViewers(float change)
    {
        viewers += change;
    }

    public void QuitCheck()
    {
        QuitButton.SetActive(false);
        QuitMenu.SetActive(true);
    }
    public void QuitEnd()
    {
        QuitButton.SetActive(true);
        QuitMenu.SetActive(false);
    }
    public void EndStream()
    {
        Debug.Log("tester");
        QuitButton.SetActive(false);
        QuitMenu.SetActive(false);
        time = 0;
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

        if (viewers < 1)
        {
            viewers = 1;
        }
        if (mood < 0)
        {
            mood = 0;
        }
        if (mood > 99.9)
        {
            mood = 99.9f;
        }

        if (mood >= 60)
        {
            moodPicture.texture = happy;
        }
        else if(mood <= 30)
        {
            moodPicture.texture = sad;
        }
        else
        {
            moodPicture.texture = middle;
        }

        if (points < 0)
        {
            points = 0;
        }
        if (points > 100)
        {
            points = 100;
        }
        if (time <= 20)
        {
            clockPicture.color = Color.red;
        }

        if (time <= 0)
        {
            time = 0;

            if (transitionStarted) return;

            transitionStarted = true;

            print("End scene");
            GameManager.highestviewers = highestviewers;
            GameManager.avargeChatMood = maxMood / numberMood;
            GameManager.endOfDayMoney = money;
            GameManager.currentmoney = money;
            //transition to next scene
            FadeManager.Instance.FadeAndLoadScene("StreamResults");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }


        moneyText.text = Mathf.FloorToInt(money).ToString() + "/" + Mathf.FloorToInt(goal).ToString();
        //goalText.text = "Goal:  $" + Mathf.FloorToInt(goal);
        ViewersText.text = Mathf.FloorToInt(viewers).ToString();
        moodText.text = Mathf.FloorToInt(mood) + "%";
        timeText.text = Mathf.FloorToInt(time).ToString();

        //Debug.Log("Points: " + points);
    }
}
