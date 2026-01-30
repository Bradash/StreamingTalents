using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    public RectTransform contentRect2;
    public TMP_Text txt;

    public float Height { get; private set; }

    void Start()
    {
        if (Random.Range(1, 3) == 2)
        {
            txt.text = "Beep";
        }
        if (Random.Range(1, 3) == 2)
        {
            txt.text = "vbufireovbfjbdejvbijbrfeivbufrbivbufireovbfjbdejv";
        }
        if (Random.Range(1, 3) == 2)
        {
            txt.text = "I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you, I love you";
        }
        ForceRebuild();
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

