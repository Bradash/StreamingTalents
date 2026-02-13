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

    private Vector2 gamePos;
    private Vector2 chatingPos;
    private Vector2 gameScale;
    private Vector2 chatingScale;

    public static CollabExpressionController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        gamePos = new Vector2(3.25f, -1);
        chatingPos = new Vector2(1.25f, -1);
        gameScale = new Vector2(0.15f, 0.15f);
        chatingScale = new Vector2(0.15f, 0.15f);

        if (UIStatsManager.Instance.game == 0)
        {
            transform.position = chatingPos;
            transform.localScale = chatingScale;
        }
        else
        {
            transform.position = gamePos;
            transform.localScale = gameScale;
        }

        currentCollab = UIStatsManager.Instance.collab;

        print(currentCollab);

        Instance = this;
        if (currentCollab == 1)
        {
            collabVtuberImage.sprite = UnicornEmotionSprites[0].sprite;
        }
        else if (currentCollab == 2)
        {
            collabVtuberImage.sprite = DragonEmotionSprites[0].sprite;
        }
        else
        {
            collabVtuberImage.sprite = null;
        }
        startPos = collabVtuberImage.transform.localPosition;
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
            if (currentCollab == 1)
            {
                target = UnicornEmotionSprites[0].sprite;
            }
            else if (currentCollab == 2)
            {
                target = DragonEmotionSprites[0].sprite;
            }
            else
            {
                target = null;
            }

        collabVtuberImage.sprite = target;

        yield return StartCoroutine(Bob());

        yield return new WaitForSeconds(duration);

        
        if (currentCollab == 1)
        {
            collabVtuberImage.sprite = UnicornEmotionSprites[0].sprite;
        }
        else if (currentCollab == 2)
        {
            collabVtuberImage.sprite = DragonEmotionSprites[0].sprite;
        }
        else
        {
            collabVtuberImage.sprite = null;
        }
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
