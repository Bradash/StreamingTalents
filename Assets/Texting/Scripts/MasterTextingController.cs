using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterTextingController : MonoBehaviour
{

    public GameObject quitbutton;
    public GameObject newsquitbutton;
    public GameObject newsbutton;
    public GameObject textoptions;
    public GameObject backarrow;
    public GameObject profile;
    public GameObject startingmessagearea;
    public GameObject messagearea;
    public GameObject newsarea;
    public GameObject news;
    public GameObject news0;

    public TextMeshProUGUI Title;
    public Image profilePicture;

    public TextingRunner runner;
    public List<TextingThread> allThreads;

    public static MasterTextingController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        showMain();
    }

    public void showMain()
    {
        //Change screeen

        quitbutton.SetActive(true);
        newsbutton.SetActive(true);
        newsquitbutton.SetActive(false);
        textoptions.SetActive(false);
        backarrow.SetActive(false);
        profile.SetActive(false);
        startingmessagearea.SetActive(true);
        messagearea.SetActive(false);
        newsarea.SetActive(false);
        news.SetActive(false);

        Title.text = "Messages";


    }

    public void showMessage(MessageGroup character)
    {
        //Change screeen

        quitbutton.SetActive(false);
        newsbutton.SetActive(false);
        newsquitbutton.SetActive(false);
        textoptions.SetActive(true);
        backarrow.SetActive(true);
        profile.SetActive(true);
        startingmessagearea.SetActive(false);
        messagearea.SetActive(true);
        newsarea.SetActive(false);
        news.SetActive(false);

        Title.text = character.displayName;
        profilePicture.sprite = character.defaultProfilePicture;

        foreach (TextingThread thread in allThreads)
        {
            if (thread.participants.Contains(character) && thread.day == GameManager.currentday)
            {
                runner.StartThread(thread);
                break;
            }
        }

    }

    public void showNews()
    {
        //Change screeen

        quitbutton.SetActive(false);
        newsbutton.SetActive(false);
        newsquitbutton.SetActive(true);
        textoptions.SetActive(false);
        backarrow.SetActive(false);
        profile.SetActive(false);
        startingmessagearea.SetActive(false);
        messagearea.SetActive(false);
        newsarea.SetActive(true);

        Title.text = "News";

        if(GameManager.currentday == 0)
        {
            news.SetActive(true);
            news0.SetActive(true);
        }
        else
        {
            news.SetActive(false);
        }

    }


}
