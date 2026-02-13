using System.Collections;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Topics;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; }

    [Header("UI")]
    public GameObject panel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI messageText;

    [Header("Timing")]
    public float charDelay = 0.03f;
    public float bufferAfterText = 1f;

    public bool IsTalking { get; private set; }

    Coroutine currentRoutine;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        panel.SetActive(false);
    }

    public void startChain(string mainMessage, OtherEmotionBase deerEmotion, string collabMessage, OtherEmotionBase collabEmotion)
    {
        if (IsTalking) return;
        print(collabEmotion);

        StartCoroutine(ReactionRoutine(mainMessage, deerEmotion, collabMessage, collabEmotion));
    }


    IEnumerator ReactionRoutine(string mainMessage, OtherEmotionBase deerEmotion, string collabMessage, OtherEmotionBase collabEmotion)
    {
        print("recived");
        print("again");
        IsTalking = true;
        panel.SetActive(true);

        yield return PlaySingleReaction(mainMessage, 0, deerEmotion);

        if (CollabExpressionController.Instance.currentCollab != 0)
        {
           yield return new WaitForSeconds(0.25f);
            yield return PlaySingleReaction(collabMessage, CollabExpressionController.Instance.currentCollab, collabEmotion);
        }

        panel.SetActive(false);
        IsTalking = false;
    }

    IEnumerator PlaySingleReaction(string message, int person, OtherEmotionBase collabEmotion)
    {
        float typeDuration = message.Length * charDelay + 0.1f;

        if (person == 0)
        {
            nameText.text = "Zara:";
            messageText.color = Color.green;
            nameText.color = Color.green;
            DeerAnimations.Instance.DeerRespondToMessage(collabEmotion, typeDuration + 0.4f);
        }
        if (person == 1)
        {
            nameText.text = "Ada: ";
            messageText.color = Color.blue;
            nameText.color = Color.blue;
            CollabExpressionController.Instance.RespondToMessage(collabEmotion, typeDuration);
        }
        if (person == 2)
        {
            nameText.text = "Ember: ";
            messageText.color = Color.red;
            nameText.color = Color.red;
            CollabExpressionController.Instance.RespondToMessage(collabEmotion, typeDuration);
        }

        messageText.enableAutoSizing = true;
        messageText.text = message;

        messageText.ForceMeshUpdate();
        LayoutRebuilder.ForceRebuildLayoutImmediate(messageText.rectTransform);

        float finalFontSize = messageText.fontSize;

        messageText.enableAutoSizing = false;
        messageText.fontSize = finalFontSize;

        messageText.text = "";

        // Force layout update so auto-size happens BEFORE typing
        LayoutRebuilder.ForceRebuildLayoutImmediate(
            messageText.rectTransform
        );

        yield return TypeText(message);

        float waitTime =
            bufferAfterText +
            (message.Length * charDelay * 0.5f);

        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator TypeText(string fullText)
    {
        messageText.text = "";

        foreach (char c in fullText)
        {
            messageText.text += c;
            yield return new WaitForSeconds(charDelay);
        }
    }
}


