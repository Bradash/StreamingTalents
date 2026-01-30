using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    public RectTransform contentRect2;
    public TMP_Text message;
    public TMP_Text username;
    public Usernames[] names;  // Assign your ScriptableObjects here in the inspector

    public float Height { get; private set; }

    void Start()
    {
        if (Random.Range(1, 1) == 1)
        {
            message.text = "Beep";
        }
        var randomUser = GetRandomUsername();
        if (randomUser != null)
        {
            username.text = randomUser.messageText;
        }
        ForceRebuild();
    }

    public Usernames GetRandomUsername()
    {
        if (names.Length == 0) return null;
        int index = Random.Range(0, names.Length);
        return names[index];
    }

    public void ForceRebuild()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect2);
        Height = contentRect2.rect.height;
    }



    // Update is called once per frame
    void Update()
    {

    }
}

