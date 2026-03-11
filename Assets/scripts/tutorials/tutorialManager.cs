using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    float timer = 0f;
    float timeLimit = 0f;


    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI tutorialTitleObject;
    [SerializeField] private TextMeshProUGUI tutorialTextObject;

    public void playTutorial(string tutorialTitle, string tutorialText, float timeLimitChange)
    {
        timer = 0f;
        timeLimit = timeLimitChange;
        print(GameManager.tutorialList[tutorialTitle][tutorialText]);
        if (GameManager.tutorialList[tutorialTitle][tutorialText] == true) {
            return;
                }
        
        tutorialTitleObject.text = tutorialTitle;
        tutorialTextObject.text = tutorialText;
        tutorialPanel.SetActive(true);
        GameManager.tutorialList[tutorialTitle][tutorialText] = true;
    }

    void closeTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    private void Update()
    {
        if (tutorialPanel.activeSelf) {
            timer += 1 * Time.deltaTime;

            if (timer > timeLimit)
            {
                closeTutorial();
            } 
        }
    }
}
