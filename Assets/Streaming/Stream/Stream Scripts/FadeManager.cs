using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [SerializeField] private Image fadeImage;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FadeAndLoadScene(string sceneName, float fadeOutTime = 4f, float fadeInTime = 2f)
    {
        StartCoroutine(FadeRoutine(sceneName, fadeOutTime, fadeInTime));
    }

    private IEnumerator FadeRoutine(string sceneName, float fadeOutTime, float fadeInTime)
    {
        yield return Fade(0f, 1f, fadeOutTime);

        SceneManager.LoadScene(sceneName);

        yield return null; // wait one frame so the new scene loads

        yield return Fade(1f, 0f, fadeInTime);
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        float time = 0f;

        Color c = fadeImage.color;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            c.a = Mathf.Lerp(from, to, t);
            fadeImage.color = c;
            yield return null;
        }

        c.a = to;
        fadeImage.color = c;
    }
}