using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Topics;

public class TopicManager : MonoBehaviour
{
    [Header("Timing")]
    public float minDelay = 20f;
    public float maxDelay = 50f;

    [Header("UI")]
    public GameObject topicPanel;
    public TopicButton buttonPrefab;
    public Transform buttonContainer;

    [Header("Topics")]
    public Topics[] allTopics;

    public float verticalSpacing = 80f; // YOU tweak this

    Coroutine topicRoutine;

    void Start()
    {
        topicPanel.SetActive(false);
        topicRoutine = StartCoroutine(TopicLoop());
    }

    IEnumerator TopicLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            ShowTopics();

            // Wait until player picks one
            while (topicPanel.activeSelf)
                yield return null;
        }
    }

    void ShowTopics()
    {

        topicPanel.SetActive(true);

        ClearButtons();

        buttonsSpawned = 0;

        Topics t1 = GetRandomValidTopic();
        Topics t2 = GetRandomValidTopic(t1);

        CreateButton(t1);
        CreateButton(t2);
    }

    int buttonsSpawned = 0;

    void CreateButton(Topics topic)
    {
        TopicButton btn = Instantiate(buttonPrefab, buttonContainer);

        RectTransform rt = btn.GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(
            0f,
            -buttonsSpawned * verticalSpacing
        );

        btn.Setup(topic, this);

        buttonsSpawned++;
    }

    void ClearButtons()
    {
        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);
    }

    Topics GetRandomValidTopic(Topics exclude = null)
    {
        List<Topics> valid = new();

        foreach (var t in allTopics)
        {
            if (t == exclude) continue;
            valid.Add(t);
        }

        return valid[Random.Range(0, valid.Count)];
    }

    public void SelectTopic(Topics topic)
    {
        ApplyTopic(topic);
        topicPanel.SetActive(false);
    }

    void ApplyTopic(Topics topic)
    {
        UIStatsManager.Instance.AddMood(topic.moodChange);
        UIStatsManager.Instance.AddViewers(topic.viewerChange);

        int collab = CollabExpressionController.Instance.currentCollab;

        if (collab == 0)
        {
            DialogueController.Instance.startChain(
                topic.DeerReaction, topic.DeerEmotion,
                null,
                topic.DragonEmotion
            );
        }
        else if (collab == 1)
        {
            DialogueController.Instance.startChain(
                topic.DeerReaction, topic.DeerEmotion,
                topic.UnicornReaction,
                topic.UnicornEmotion
            );
        }
        else if (collab == 2)
        {
            DialogueController.Instance.startChain(
                topic.DeerReaction, topic.DeerEmotion,
                topic.DragonReaction,
                topic.DragonEmotion
            );
        }
    }
}
