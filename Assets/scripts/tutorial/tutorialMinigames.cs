using System.Linq;
using UnityEngine;

public class tutorialMinigames : MonoBehaviour
{
    public GameObject Rhythm;
    public GameObject Flappybird;
    public GameObject Tycoon;

    public tutorialManager tutorialManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.currentday != 0)
        {
            
            if (!GameManager.seenBird && Flappybird.activeInHierarchy) { 
                tutorialManager.playTutorial("Cave Flyer", GameManager.tutorialList["Cave Flyer"].Keys.First(), 15f, true);
                Time.timeScale = 0;
            }
            else if (!GameManager.seenTycoon && Tycoon.activeInHierarchy) { 
                tutorialManager.playTutorial("Tycoon", GameManager.tutorialList["Tycoon"].Keys.First(), 15f, true);
                Time.timeScale = 0;
            }
            else if (!GameManager.seenRhythm && Rhythm.activeInHierarchy) { 
               tutorialManager.playTutorial("Rhythm", GameManager.tutorialList["Rhythm"].Keys.First(), 15f, true);
                Time.timeScale = 0;
            }
            /*else if (!GameManager.seenTemple && laneChanger.activeInHierarchy)
            {
                tutorialManager.playTutorial("Lane Changer", GameManager.tutorialList["Lane Changer"].Keys.First(), 15f, true);
                Time.timeScale = 0;
            }
            */

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
