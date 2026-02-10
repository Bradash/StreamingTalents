using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopicButton : MonoBehaviour
{
    public TMP_Text label;
    Button button;

    Topics topic;
    TopicManager manager;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    public void Setup(Topics newTopic, TopicManager topicManager)
    {
        topic = newTopic;
        manager = topicManager;
        label.text = topic.TopicName;
    }

    void OnClicked()
    {
        if (DialogueController.Instance.IsTalking) return;
        manager.SelectTopic(topic);
    }
}