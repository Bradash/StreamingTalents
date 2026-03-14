using UnityEngine;

public class MasterTextingController : MonoBehaviour
{
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

    void showMain()
    {

    }

    void showMessage()
    {

    }

    void showNews()
    {

    }

    void quitTexting()
    {
        FadeManager.Instance.FadeAndLoadScene("IRL");
    }
}
