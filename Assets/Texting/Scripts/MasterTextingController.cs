using TMPro;
using UnityEngine;

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

    public TextMeshProUGUI Title;

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

        Title.text = character.displayName;

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

    }

    void quitTexting()
    {
        FadeManager.Instance.FadeAndLoadScene("IRL");
    }
}
