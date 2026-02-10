using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestLayout : MonoBehaviour
{
    public GameObject messagePrefab;
    public RectTransform chatContainer;

    void Start()
    {
        // Spawn 3 messages of different lengths
        SpawnMessage("Short message");
        SpawnMessage("This is a bit longer message to show resizing");
        SpawnMessage("This is a really really really long message to prove the layout system works and resizes the box!");
    }

    void SpawnMessage(string text)
    {
        GameObject msg = Instantiate(messagePrefab, chatContainer);
        msg.transform.SetAsLastSibling(); // bottom of the stack
        msg.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
