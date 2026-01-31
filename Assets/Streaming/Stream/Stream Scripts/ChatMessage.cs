using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    public RectTransform contentRect2;
    public TMP_Text message;
    public TMP_Text username;
    public Usernames[] names;  // Assign your ScriptableObjects here in the inspector
    public Image profileImage;        // The UI Image
    public Sprite[] profilePictures;  // Drag sprites here
    public Messages[] messages1;    // Stage 1
    public Messages[] messages2;    // Stage 2
    public Messages[] messages3;    // Stage 3
    public GameState gameState;

    public float Height { get; private set; }

    void Start()
    {
        var randomMessage = GetRandomMessage();
        if (randomMessage != null)
        {
            message.text = randomMessage.message;
        }

        var randomUser = GetRandomUsername();
        if (randomUser != null)
        {
            username.text = randomUser.messageText;
        }

        SetRandomProfilePicture();

        ForceRebuild();
    }

    public Usernames GetRandomUsername()
    {
        if (names.Length == 0) return null;
        int index = Random.Range(0, names.Length);
        return names[index];
    }

    public Messages GetRandomMessage()
    {
        if (gameState.narrativeState == 1)
        {
            if (messages1.Length == 0) return null;
            int index = Random.Range(0, messages1.Length);
            return messages1[index];
        }
        if (gameState.narrativeState == 2)
        {
            if (messages2.Length == 0) return null;
            int index = Random.Range(0, messages2.Length);
            return messages2[index];
        }
        if (gameState.narrativeState == 3)
        {
            if (messages3.Length == 0) return null;
            int index = Random.Range(0, messages3.Length);
            return messages3[index];
        }
        return null;
    }

    public void ForceRebuild()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect2);
        Height = contentRect2.rect.height;
    }

    void SetRandomProfilePicture()
    {
        if (profilePictures.Length == 0)
            return;

        int index = Random.Range(0, profilePictures.Length);
        profileImage.sprite = profilePictures[index];

        profileImage.preserveAspect = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.position.y);
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}

