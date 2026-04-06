using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int quest1Progress;
    public string questName;
    public GameObject[] gameObjects;
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI dayText;
    public tutorialManager tutorialManage;
    public BoxCollider coffeeMachineCollider;

    public IRLFadeManager Instance;

    public void Start()
    {
        dayText.text = "Day: " + loadDay();
        if (GameManager.currentday == 0)
            tutorialManage.playTutorial("Movement", GameManager.tutorialList["Movement"].Keys.First(), 7.5f, false);
    }
    public string loadDay()
    {
        if (GameManager.currentday == 0)
        {
            return "Tutorial Day";
        }
        else
        {
            return GameManager.currentday.ToString();
        }
    }
    public void computerInteract()
    {
        switch (quest1Progress)
        {
            case 0:
                questName = "I need to head to the bathroom";
                break;
            case 1:
                questName = "I need to make coffee";
                break;
            case 2:
                questName = "I need to get food";
                break;
            case 3:
                questName = "I need to pick up the food";
                break;
            case 4:
                questName = null;
                Instance.FadeAndLoadScene("SteamSetup");
                break;
        }
    }
    public void objectInteract()
    {
        switch (quest1Progress) 
        {
            case 0:
                break;
            case 1:
                Instance.bathroomFade();
                coffeeMachineCollider.enabled = true;
                gameObjects[0].SetActive(false);
                taskText.text = "Task: \r\nMake Coffee";
                break;
            case 2:
                gameObjects[1].SetActive(true);
                gameObjects[3].transform.position = new Vector3(1.80900002f, 0.999000013f, -10.3839998f);
                gameObjects[3].GetComponentInChildren<AudioSource>().Play();
                taskText.text = "Task: \r\nOpen Door";
                break;
            case 3:
                gameObjects[2].SetActive(true);
                gameObjects[1].SetActive(false);
                taskText.text = "Task: \r\nGet Food";
                break;
            case 4:
                gameObjects[2].SetActive(false);
                gameObjects[4].SetActive(true);
                taskText.text = "Task: \r\nGo to PC";
                break;
        }
    }
}
