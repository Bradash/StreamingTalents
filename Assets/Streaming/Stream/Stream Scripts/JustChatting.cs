using TMPro;
using UnityEngine;

public class JustChatting : MonoBehaviour
{
    public TextMeshProUGUI tutorial;
    public DialogueController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tutorial.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsTalking)
        {
            tutorial.enabled = false;
        }
    }
}
