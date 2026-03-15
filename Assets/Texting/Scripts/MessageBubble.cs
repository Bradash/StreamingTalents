using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBubble : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Image profileImage;
    public Image profileImageHelper;

    VerticalLayoutGroup myLayoutGroup;
    public Image bubbleImage;

    public RectTransform bubbleRect;
    TextMessage myMessage;

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


    public void Setup(TextMessage message, VerticalLayoutGroup layoutGroup)
    {
        myMessage = message;

        //myLayoutGroup = layoutGroup;

        messageText.text = myMessage.message;

        
        if (myMessage.groupChat)
        {
            profileImage.gameObject.SetActive(true);
            profileImageHelper.gameObject.SetActive(true);
            profileImage.sprite = myMessage.GroupChatspeaker.defaultProfilePicture;
        }
        else
        {
            profileImage.gameObject.SetActive(false);
            profileImageHelper.gameObject.SetActive(false);
        }

        if (myMessage.speaker.displayName == "Zara")
        {
            transform.localScale = new Vector3(-1, 1, 1);
            messageText.transform.localScale = new Vector3(-1, 1, 1);
            bubbleImage.color = new Color(0.6f, 1f, 0.6f); // green bubble
        }
        else
        {
            transform.localScale = Vector3.one;
            messageText.transform.localScale = Vector3.one; 
            bubbleImage.color = Color.white;
        }

    }
}