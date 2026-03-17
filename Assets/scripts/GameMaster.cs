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
    public void Start()
    {
        dayText.text = "Day: " + loadDay();
        if (GameManager.currentday == 1)
            tutorialManage.playTutorial("Movement", GameManager.tutorialList["Movement"].Keys.First(), 7.5f, false);
    }
    public int loadDay()
    {
        return GameManager.currentday;
    }
    public void computerInteract()
    {
        switch (quest1Progress)
        {
            case 0:
                questName = "I need to make coffee";
                break;
                case 1:
                questName = "I need to get food";
                break; 
            case 2:
                questName = "I need to pick up the food";
                break;
            case 3:
                questName = null;
                FadeManager.Instance.FadeAndLoadScene("SteamSetup");
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
                gameObjects[0].SetActive(true);
                gameObjects[2].SetActive(true);
                taskText.text = "Task: \r\nOpen Door";
                break;
            case 2:
                gameObjects[1].SetActive(true);
                gameObjects[0].SetActive(false);
                taskText.text = "Task: \r\nGet Food";
                break;
            case 3:
                gameObjects[1].SetActive(false);
                gameObjects[3].SetActive(true);
                taskText.text = "Task: \r\nGo to PC";
                break;
        }
    }
}
