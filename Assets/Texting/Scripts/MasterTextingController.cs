using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

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
    public GameObject news1;
    public GameObject news2;
    public GameObject news3;
    public GameObject news4;
    public GameObject news5;
    public GameObject news6;
    public GameObject news7;
    public GameObject news8;

    public TextMeshProUGUI Title;
    public Image profilePicture;

    public GameObject managerNote;
    public GameObject wolfNote;
    public GameObject unicornNote;
    public GameObject dragonNote;
    public GameObject companyNote;

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

        if (character.name == "Boss")
        {
            managerNote.SetActive(false);
        }
        if (character.name == "Desmond")
        {
            wolfNote.SetActive(false);
        }
        if (character.name == "Ada")
        {
            unicornNote.SetActive(false);
        }
        if (character.name == "Ember")
        {
            dragonNote.SetActive(false);
        }
        if (character.name == "Boss")
        {
            companyNote.SetActive(false);
        }


        foreach (TextingThread thread in TextSpawner.Instance.allThreads)
        {
            Debug.Log(thread);
            if (thread.participants == character && thread.day == GameManager.currentday)
            {
                TextSpawner.Instance.ClearMessages();
                TextSpawner.Instance.ClearOptions();

                TextSpawner.Instance.StartThread(thread);
                return;
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

        news.SetActive(true);

        news0.SetActive(false);
        news1.SetActive(false);
        news2.SetActive(false);
        news3.SetActive(false);
        news4.SetActive(false);
        news5.SetActive(false);
        news6.SetActive(false);
        news7.SetActive(false);
        news8.SetActive(false);

        if (GameManager.currentday == 0)
        {
            news0.SetActive(true);
        }
        if (GameManager.currentday == 1)
        {
            news1.SetActive(true);
        }
        if (GameManager.currentday == 2)
        {
            news2.SetActive(true);
        }
        if (GameManager.currentday == 3)
        {
            news3.SetActive(true);
        }
        if (GameManager.currentday == 4)
        {
            news4.SetActive(true);
        }
        if (GameManager.currentday == 5)
        {
            news5.SetActive(true);
        }
        if (GameManager.currentday == 6)
        {
            news6.SetActive(true);
        }
        if (GameManager.currentday == 7)
        {
            news7.SetActive(true);
        }
        if (GameManager.currentday == 8)
        {
            news8.SetActive(true);
        }

    }


}
