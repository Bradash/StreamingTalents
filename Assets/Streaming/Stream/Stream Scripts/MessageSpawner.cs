using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
    public StreamLogic StreamLogic;
    public RectTransform container;
    private readonly List<ChatMessage> messages = new();
    ChatMessage currentChat;

    float viewCount;
    float messageCounter;
    float pilledUpMessages;
    float punishment = 0.2f;

    int hoverCount = 0;
    public bool pause;
    //int maxMessages = 13;

    //new Vector2(1280, 720)

    public GameObject Chatter;
    //public Transform chatBox;

    public static MessageSpawner Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        messageCounter = 0;

        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        viewCount = UIStatsManager.Instance.viewers;

        if (pause)
        {
            Time.timeScale = 0;
        }
        else if (hoverCount > 0)
        {
            Time.timeScale = 0.1f;
            Debug.Log("Slowdown");
        }
        else
        {
            Time.timeScale = 1f;
        }

        //Time.timeScale = 0.5f;

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
                messageCounter += (Time.deltaTime * ((Mathf.Log10(viewCount) + 1) * 2)) / 16;
                pilledUpMessages += Time.deltaTime * Random.Range(0.1f, 0.6f);
                if (pilledUpMessages >= 3)
                {
                    messageCounter += Mathf.Log10(viewCount);
                    pilledUpMessages -= 3;
                }
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
        //float yTotal = 0f;

        //for (int i = messages.Count - 1; i >= 0; i--)
        //{
        //    RectTransform rt = messages[i].GetComponent<RectTransform>();
        //    rt.anchoredPosition = new Vector2(0f, y);
        //    y += (messages[i].Height / 100);
        //    yTotal += y;
        //    print(messages[i].Height / 100);
        //
        //}

            foreach (ChatMessage msg in messages)
        {
            if (msg != null)
            {
                RectTransform rt = msg.GetComponent<RectTransform>();
                y += (msg.Height / 100);
                rt.anchoredPosition = new Vector2(0f, y);
                //print(msg.Height / 100);
            }
        }
    }

    public void PunishBans()
    {
        UIStatsManager.Instance.AddMood(-punishment);
        UIStatsManager.Instance.AddViewers(-punishment * 10);
        punishment += 0.5f;
        punishment -= Time.deltaTime * 0.1f;
    }

    public void HoverStart()
    {
        hoverCount++;
    }

    public void HoverEnd()
    {
        hoverCount--;
        hoverCount = Mathf.Max(hoverCount, 0);
    }

}