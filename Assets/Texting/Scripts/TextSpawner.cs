using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class TextSpawner : MonoBehaviour
{
    public MessageBubble messagePrefab;
    public Transform messageParent;
    public VerticalLayoutGroup layoutGroup;

    public OptionButton optionPrefab;
    public Transform optionParent;

    public float messageDelay = 1.5f;
    TextMessage currentMessage;
    public List<TextingThread> allThreads;
    Dictionary<MessageGroup, List<TextMessage>> threadHistory = new Dictionary<MessageGroup, List<TextMessage>>();

    public ScrollRect scrollRect;
    public RectTransform contentRect;

    public GameObject backArrow;
    public bool inMessage;

    //Temp
    //public TextMessage currentMessage1;
    MessageGroup activeCharacter;

public static TextSpawner Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        inMessage = false;
    }

    void Start()
    {
        inMessage = false;
    }

    private void Update()
    {
        //print(threadHistory[activeCharacter]);
        //foreach (var x in threadHistory[activeCharacter])
        //{
        //    Debug.Log(x.ToString());
        //}
    }

    public void StartConversation(TextMessage firstMessage)
    {
        inMessage = true;
        backArrow.SetActive(false);

        StartCoroutine(RunMessage(firstMessage));
    }

    public void StartThread(TextingThread thread)
    {
        inMessage = true;
        backArrow.SetActive(false);
        if (thread == null)
        {
            EndConversation();
            return;
        }

        if (thread.startingMessage == null)
        {
            Debug.LogWarning("Thread has no starting message.");
            EndConversation();
            return;
        }

        activeCharacter = thread.participants;

        ClearMessages();
        ClearOptions();

        // First time opening conversation
        if (!threadHistory.ContainsKey(activeCharacter))
        {
            threadHistory[activeCharacter] = new List<TextMessage>();
            StartConversation(thread.startingMessage);
            return;
        }

        List<TextMessage> history = threadHistory[activeCharacter];

        // Rebuild all previous messages
        foreach (TextMessage message in history)
        {
            Spawn(message);
        }

        // Handle the latest message's behavior
        if (history.Count > 0)
        {
            TextMessage lastMessage = history[history.Count - 1];
            ResumeFromMessage(lastMessage);
        }
    }

    IEnumerator RunMessage(TextMessage message)
    {
        if (message == null)
            yield break;
        if (activeCharacter == null)
            yield break;
        if (activeCharacter != message.speaker)
        {
            if (message.speaker.displayName != "Zara")
            {
                yield break;
            }
        }

        currentMessage = message;

        Spawn(message);

        currentMessage = message;
        if (!threadHistory[activeCharacter].Contains(message))
        {
            threadHistory[activeCharacter].Add(message);
        }

        Debug.Log(message.groupChat + " " + activeCharacter);
        yield return new WaitForSeconds(messageDelay);

        if (message == null)
            yield break;
        if (activeCharacter == null)
            yield break;
        if (activeCharacter != message.speaker)
        {
            if (message.speaker.displayName != "Zara")
            {
                yield break;
            }
        }

        if (message.flowType == MessageFlowType.Auto)
        {
            if (message.nextMessage != null)
            {
                StartCoroutine(RunMessage(message.nextMessage));
            }
        }

        else if (message.flowType == MessageFlowType.Question)
        {
            if (message.options == null || message.options.Count == 0)
            {
                EndConversation();
            }
            else
            {
                SpawnOptions(message.options);
            }
        }

        if (message.flowType == MessageFlowType.Auto && message.nextMessage == null)
        {
            EndConversation();
        }
    }

    void ResumeFromMessage(TextMessage message)
    {
        if (message == null)
            return;

        if (message.flowType == MessageFlowType.Question)
        {
            if (message.options == null || message.options.Count == 0)
            {
                EndConversation();
            }
            else
            {
                SpawnOptions(message.options);
            }
        }
        else if (message.flowType == MessageFlowType.Auto)
        {
            if (message.nextMessage != null)
            {
                StartCoroutine(RunMessage(message.nextMessage));
            }
        }
    }

    void Spawn(TextMessage message)
    {
        MessageBubble bubble = Instantiate(messagePrefab, messageParent);
        bubble.Setup(message, layoutGroup);

        StartCoroutine(ScrollNextFrame());
    }

    public void SpawnOptions(List<TextingOption> options)
    {
        foreach (TextingOption option in options)
        {
            OptionButton button = Instantiate(optionPrefab, optionParent);
            button.Setup(option);
        }
    }

    public void ClearOptions()
    {
        foreach (Transform child in optionParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void ContinueConversation(TextMessage message)
    {
        if (message == null)
        {
            EndConversation();
            return;
        }

        Spawn(message);

        threadHistory[activeCharacter].Add(message);

        if (message.flowType == MessageFlowType.Question)
        {
            if (message.options == null || message.options.Count == 0)
            {
                EndConversation();
            }
            else
            {
                SpawnOptions(message.options);
            }
        }
        else if (message.nextMessage == null)
        {
            EndConversation();
        }
    }

    public void ClearMessages()
    {
        foreach (Transform child in messageParent)
        {
            Destroy(child.gameObject);
        }
    }

    void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect);

        scrollRect.verticalNormalizedPosition = 0f;
    }

    IEnumerator ScrollNextFrame()
    {
        yield return null;

        ScrollToBottom();
    }

    public void EndConversation()
    {
        inMessage = false;
        backArrow.SetActive(true);

        Debug.Log("Conversation ended");
        // exitButton.interactable = true;
    }


}

