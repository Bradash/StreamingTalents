using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBubble : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Image profileImage;

    public RectTransform bubbleRect;
    public TextMessage message;

    void Start()
    {
        /*
        bonusApplied = false;

        messageData = GetRandomMessage();
        if (messageData != null)
        {
            message.text = messageData.message;
            ApplyEffects();
        }

        var randomUser = GetRandomUsername();
        if (randomUser != null)
        {
            username.text = randomUser.messageText;
        }

        SetRandomProfilePicture();

        ForceRebuild();
        */
    }


    public void Setup(string text, Sprite profile, bool isPlayer, bool groupChat)
    {
        messageText.text = text;

        if (groupChat)
        {
            profileImage.gameObject.SetActive(true);
            profileImage.sprite = profile;
        }
        else
        {
            profileImage.gameObject.SetActive(false);
        }

        if (isPlayer)
        {
            // flip layout so message appears on right
            transform.localScale = new Vector3(-1, 1, 1);
            messageText.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
            messageText.transform.localScale = Vector3.one;
        }
    }
}