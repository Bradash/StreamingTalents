using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextingRunner : MonoBehaviour
{
    public Transform messageContainer;

    public GameObject leftMessagePrefab;
    public GameObject rightMessagePrefab;

    public GameObject optionButtonPrefab;
    public Transform optionContainer;

    public ScrollRect scrollRect;

    public float messageDelay = 1.2f;

    private TextMessage currentMessage;


    public void StartThread(TextingThread thread)
    {
        StartCoroutine(RunMessage(thread.startingMessage));
    }

    IEnumerator RunMessage(TextMessage message)
    {
        currentMessage = message;

        SpawnMessage(message);

        yield return new WaitForSeconds(messageDelay);

        if (message.flowType == MessageFlowType.Auto)
        {
            if (message.nextMessage != null)
            {
                StartCoroutine(RunMessage(message.nextMessage));
            }
        }
        else if (message.flowType == MessageFlowType.Question)
        {
            ShowOptions(message);
        }
    }

    void SpawnMessage(TextMessage message)
    {
        GameObject prefab;

        if (message.speaker.displayName == "Zara")
            prefab = rightMessagePrefab;
        else
            prefab = leftMessagePrefab;

        GameObject bubble = Instantiate(prefab, messageContainer);

        TextMeshProUGUI text = bubble.GetComponentInChildren<TextMeshProUGUI>();
        text.text = message.message;

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    void ShowOptions(TextMessage message)
    {
        foreach (Transform child in optionContainer)
            Destroy(child.gameObject);

        foreach (TextingOption option in message.options)
        {
            GameObject btn = Instantiate(optionButtonPrefab, optionContainer);

            btn.GetComponentInChildren<TextMeshProUGUI>().text = option.optionText;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                ChooseOption(option);
            });
        }
    }

    void ChooseOption(TextingOption option)
    {
        GameManager.wolfRelationship += option.WolfRelationChange;
        GameManager.unicornRelationship += option.UnicornRelationChange;
        GameManager.dragonRelationship += option.DragonRelationChange;

        foreach (Transform child in optionContainer)
            Destroy(child.gameObject);

        StartCoroutine(RunMessage(option.nextMessage));
    }

}