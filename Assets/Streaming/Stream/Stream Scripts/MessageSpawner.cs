using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MessageSpawner : MonoBehaviour
{
    public StreamLogic StreamLogic;
    public RectTransform container;
    private readonly List<ChatMessage> messages = new();
    ChatMessage currentChat;

    float spacing = 6f;

    float veiwCount;
    float messageCounter;
    float pilledUpMessages;
    //int maxMessages = 13;

    //new Vector2(1280, 720)

    public GameObject Chatter;
    //public Transform chatBox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageCounter = 0;
        veiwCount = 100; //Testing
    }

    // Update is called once per frame
    void Update()
    {
        if (StreamLogic.streamstate == 3)
        {
            if (messageCounter >= 2)
            {
                print("Sent Message");
                SpawnMessage();
                messageCounter -= 1;
            }
            else
            {
                messageCounter += (Time.deltaTime * ((Mathf.Log10(veiwCount)+1)*2))/16;
            }
        }
    }

    public void SpawnMessage()
    {
        GameObject go = Instantiate(Chatter.gameObject, container);
        ChatMessage msg = go.GetComponent<ChatMessage>();
        go.transform.position -= new Vector3(1280, 720, 0);

        msg.ForceRebuild();

        messages.Insert(0, msg);
        currentChat = msg;
        RepositionMessages();
    }

    void RepositionMessages()
    {
        float y = 0f;

        foreach (ChatMessage msg in messages)
        {
            RectTransform rt = msg.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0f, y);
            y += (msg.Height/100);
            print(msg.Height / 100);
        }
    }

}
