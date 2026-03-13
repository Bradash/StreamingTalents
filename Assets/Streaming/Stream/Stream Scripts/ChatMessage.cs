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
    public narrativeState gameState;

    public Messages messageData;   // The picked ScriptableObjects

    private bool effectsApplied;
    private bool committed;
    private bool banned;

    private int appliedMood;
    private int appliedViewers;

    private bool bonusApplied;
    public float Height { get; private set; }

    void Start()
    {
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

    public void ReadMessage()
    {
        if (bonusApplied || messageData == null) return;

        if (banned) return;

        if (DialogueController.Instance.IsTalking) return;

        //Can only read it if it hasn't been read before, there is a message to be read out, they havn't been banned, and the character isn't talking

        // Play streamer reaction here
        // uiStatsManager.PlayReaction(messageData.DeerReaction);

        UIStatsManager.Instance.AddMood(appliedMood/2);
        UIStatsManager.Instance.AddViewers(appliedViewers/2);

        int collab = CollabExpressionController.Instance.currentCollab;

        print(collab);
        
        //DialogueController.Instance.ReactionRoutine(messageData.DeerReaction, messageData.OniReaction, messageData.UnicornEmotion);

        if (collab == 0)
        {
            DialogueController.Instance.startChain(messageData.DeerReaction, messageData.DeerEmotion, null, messageData.DragonEmotion);
        }
        if (collab == 1)
        {
            DialogueController.Instance.startChain(messageData.DeerReaction, messageData.DeerEmotion, messageData.UnicornReaction, messageData.UnicornEmotion);
        }
        if (collab == 2)
        {
            DialogueController.Instance.startChain(messageData.DeerReaction, messageData.DeerEmotion, messageData.DragonReaction, messageData.DragonEmotion);
        }

        bonusApplied = true;
    }

    public void BanMessage()
    {
        if (banned) return;

        RemoveEffects();

        MessageSpawner.Instance.PunishBans();

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
        if (gameState.narState == 1)
        {
            if (messages1.Length == 0) return null;
            int index = Random.Range(0, messages1.Length);
            return messages1[index];
        }
        if (gameState.narState == 2)
        {
            if (messages2.Length == 0) return null;
            int index = Random.Range(0, messages2.Length);
            return messages2[index];
        }
        if (gameState.narState == 3)
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
    void OnMouseOver()
    {
        print("Clicker");
        if (Input.GetMouseButtonDown(0))
        {
            print("left");
            ReadMessage();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            print("Right");
            BanMessage();
        }
    }

    void OnMouseEnter()
    {
        MessageSpawner.Instance.HoverStart();
    }

    void OnMouseExit()
    {
        MessageSpawner.Instance.HoverEnd();
    }

}

