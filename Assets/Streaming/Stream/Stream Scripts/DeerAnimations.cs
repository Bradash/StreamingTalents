using UnityEngine;
using System.Collections;
using static Topics;

public class DeerAnimations : MonoBehaviour
{
    public Animator anim;
    public Transform deerObject;


    int currentAnimation; //0 = idle, 1 = shock

    private Vector2 startPos;

    private Coroutine currentRoutine;

    public EmotionAni[] DeerEmotionAni;

    [System.Serializable]
    public class EmotionAni
    {
        public OtherEmotionBase emotion;
        public int value;
    }

    public static DeerAnimations Instance { get; private set; }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        startPos = deerObject.transform.localPosition;
        anim.SetInteger("Emotion", 0);
    }


    public void DeerRespondToMessage(OtherEmotionBase emotion, float duration)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ResponseRoutine(emotion, duration));
    }

    IEnumerator ResponseRoutine(OtherEmotionBase emotion, float duration)
    {
        int target = GetSprite(emotion);

        anim.SetInteger("Emotion", target);

        yield return new WaitForSeconds(duration);

        anim.SetInteger("Emotion", 0);
    }

    int GetSprite(OtherEmotionBase emotion)
    {
        if (emotion == Topics.OtherEmotionBase.Neutral)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            anim.SetInteger("Emotion",0);

        if (Input.GetKeyDown(KeyCode.D))
            anim.SetInteger("Emotion", 1);
    }
}
