using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    float timer = 0f;
    float timerScale = 1f;
    float timeLimit = 0f;


    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI tutorialTitleObject;
    [SerializeField] private TextMeshProUGUI tutorialTextObject;
    [SerializeField] private GameObject tutorialCloseButton;

    public void playTutorial(string tutorialTitle, string tutorialText, float timeLimitChange, bool closeButton)
    {
        timer = 0f;
        timeLimit = timeLimitChange;
        print(GameManager.tutorialList[tutorialTitle][tutorialText]);
        if (GameManager.tutorialList[tutorialTitle][tutorialText] == true || GameManager.currentday != 1) {
            return;
                }

        if (closeButton == true)
        {
            tutorialCloseButton.SetActive(true);
            timerScale = 0f;
        }
        else
        {
            tutorialCloseButton.SetActive(false);
            timerScale = 1f;
        }

            tutorialTitleObject.text = tutorialTitle;
        tutorialTextObject.text = tutorialText;
        tutorialPanel.SetActive(true);
        GameManager.tutorialList[tutorialTitle][tutorialText] = true;
    }

    public void closeTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    private void Update()
    {
        if (tutorialPanel.activeSelf) {
            timer += timerScale * Time.deltaTime;

            if (timer > timeLimit)
            {
                closeTutorial();
            } 
        }
    }
}
