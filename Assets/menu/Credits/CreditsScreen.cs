using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    public GameObject EndScreen;

    public GameObject Credits;

    public GameObject money;
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        if (GameManager.currentday == 9)
        {
            moneyText.text = GameManager.currentmoney.ToString();

            EndScreen.SetActive(true);
            money.SetActive(true);
            Credits.SetActive(false);

            if (Input.GetMouseButtonDown(0))
            {
                GameManager.currentday = 8;
                SceneManager.LoadScene("Credits");
            }
        }
        else
        {
            EndScreen.SetActive(false);
            money.SetActive(false);
            Credits.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                FadeManager.Instance.FadeAndLoadScene("menu");
            }
        }
    }
}
