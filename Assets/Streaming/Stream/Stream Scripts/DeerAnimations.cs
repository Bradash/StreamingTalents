using UnityEngine;
using System.Collections;
using static Topics;

public class DeerAnimations : MonoBehaviour
{
    public Animator anim;
    public Transform deerObject;


    int currentAnimation; //0 = idle, 1 = shock

    private Coroutine currentRoutine;

    public EmotionAni[] DeerEmotionAni;

    public float blinkTimer = 0f;
    public float blinkInterval = 4f;
    public float blinkSpeed = 1f;

    [System.Serializable]
    public class EmotionAni
    {
        public OtherEmotionBase emotion;
        public int value;
    }

    private Vector3 gamePos;
    private Vector3 chatingPos;
    private Vector3 gameScale;
    private Vector3 chatingScale;

    public static DeerAnimations Instance { get; private set; }

    void Awake()
    {
        //anim.enabled = false;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        gamePos = new Vector3(-6.89f, -7.09f, -1.99f);
        chatingPos = new Vector3(-4.25f, -8.15f, -1.99f);
        gameScale = new Vector3(5, 5, 5);
        chatingScale = new Vector3(6.5f, 6.5f, 6.5f); 

        Instance = this;

        //startPos = deerObject.transform.localPosition;
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
        blinkSpeed = 0f;
        int target = GetSprite(emotion);

        anim.SetInteger("Emotion", target);

        yield return new WaitForSeconds(duration);

        anim.SetInteger("Emotion", 0);
        blinkSpeed = 1f;
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
        //blinking
        blinkTimer += blinkSpeed * Time.deltaTime;

        if (blinkTimer >= blinkInterval)
        {

            anim.SetTrigger("Blink");
            blinkTimer = 0f;
            blinkInterval = Random.Range(2.5f, 5f);
        }

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
        //transform.position = new Vector3(-3f, -8.15f, -2f);
        //print(transform.position);
    }

}
