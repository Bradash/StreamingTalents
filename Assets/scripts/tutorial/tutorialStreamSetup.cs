using System.Linq;
using UnityEngine;

public class tutorialStreamSetup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public tutorialManager tutorialManage;

    void Start()
    {
        tutorialManage.playTutorial("Stream Setup", GameManager.tutorialList["Stream Setup"].Keys.First(), 7.5f, true);

    }
}
