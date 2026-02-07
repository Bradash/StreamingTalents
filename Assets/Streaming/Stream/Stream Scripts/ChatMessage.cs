using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    public RectTransform contentRect2;
    public TMP_Text message;
    public TMP_Text username;
    public Usernames[] names;
    public Image profileImage;        // The UI Image
    public Sprite[] profilePictures;  // Drag sprites here
    public Messages[] messages1;    // Stage 1
    public Messages[] messages2;    // Stage 2
    public Messages[] messages3;    // Stage 3
    public GameState gameState;

    public Messages messageData;   // The picked ScriptableObject

    private bool effectsApplied;
    private bool committed;
    private bool banned;

    private int appliedMood;
    private int appliedViewers;

    public float Height { get; private set; }

    void Start()
    {
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
    }

    void ApplyEffects()
    {
        if (effectsApplied || messageData == null) return;

        appliedMood = messageData.moodChange;
        appliedViewers = messageData.viewerChange;

        UIStatsManager.Instance.AddMood(appliedMood);
        UIStatsManager.Instance.AddViewers(appliedViewers);

        effectsApplied = true;
    }

    void RemoveEffects()
    {
        if (!effectsApplied || committed) return;

        UIStatsManager.Instance.AddMood(-appliedMood);
        UIStatsManager.Instance.AddViewers(-appliedViewers);

        effectsApplied = false;
    }

    public void BanMessage()
    {
        if (banned) return;

        RemoveEffects();

        UIStatsManager.Instance.AddViewers(-5);

        username.color = Color.red;
        username.fontStyle = FontStyles.Bold;
        username.text = "Banned";


        message.color = Color.red;
        message.fontStyle = FontStyles.Bold;
        message.text = "Message removed";

        banned = true;
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
            RemoveEffects();
            Destroy(gameObject);
        }
    }

    //Remove later
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicker");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            print("left");
            //OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            print("Right");
            BanMessage();
        }
    }
}

