using System.Collections;
using UnityEngine;
using static CollabExpressionController;
using static Topics;

public class CollabExpressionController : MonoBehaviour
{
    public SpriteRenderer collabVtuberImage;
    public int currentCollab; //0 = null, 1=Unicorn, 2=Dragon


    [System.Serializable]
    public class EmotionSprite
    {
        public OtherEmotionBase emotion;
        public Sprite sprite;
    }

    public EmotionSprite[] DragonEmotionSprites;
    public EmotionSprite[] UnicornEmotionSprites;

    public float respondTime = 2.5f;
    public float bobHeight = 0f;
    public float bobDuration = 0.25f;

    private Coroutine currentRoutine;
    private Vector2 startPos;

    public static CollabExpressionController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        startPos = collabVtuberImage.transform.localPosition;
        collabVtuberImage.sprite = DragonEmotionSprites[0].sprite;

        //testing
        currentCollab = 2;
    }

    public void RespondToMessage(OtherEmotionBase emotion, float duration)
    {
        print("Working");
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ResponseRoutine(emotion, duration));
    }

    IEnumerator ResponseRoutine(OtherEmotionBase emotion, float duration)
    {
        Sprite target = GetSprite(emotion);
        if (target == null)
            target = DragonEmotionSprites[0].sprite;

        collabVtuberImage.sprite = target;

        yield return StartCoroutine(Bob());

        yield return new WaitForSeconds(duration);

        collabVtuberImage.sprite = DragonEmotionSprites[0].sprite;
    }

    IEnumerator Bob()
    {
        Debug.Log("Bob started");
        Transform rt = collabVtuberImage.transform;
        startPos = rt.localPosition;

        float t = 0f;
        while (t < bobDuration)
        {
            t += Time.deltaTime;
            float y = Mathf.Sin((t / bobDuration) * Mathf.PI) * bobHeight;
            rt.localPosition = startPos + Vector2.up * y;
            yield return null;
        }

        rt.localPosition = startPos;
    }

    Sprite GetSprite(OtherEmotionBase emotion)
    {
        if (currentCollab == 1)
        {
            foreach (var e in UnicornEmotionSprites)
            {
                if (e.emotion == emotion)
                    return e.sprite;
            }
        }
        if (currentCollab == 2)
        {
            foreach (var e in DragonEmotionSprites)
            {
                if (e.emotion == emotion)
                    return e.sprite;
            }
        }
        return null;
    }
}
