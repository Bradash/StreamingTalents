using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    public RectTransform contentRect1;
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
            txt.text = "vbufireovbfjbdejvbijbrfeivbufrbivbufireovbfjbdejvbijbrfeivbufrbi";
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
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect1);
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect2);
        Height = contentRect1.rect.height + contentRect2.rect.height;
    }



    // Update is called once per frame
    void Update()
    {
        print(Height);
        print(contentRect1.rect.height);
        print(contentRect2.rect.height);
    }
}

