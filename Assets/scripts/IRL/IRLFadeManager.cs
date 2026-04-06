using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IRLFadeManager : MonoBehaviour
{
    public PlayerCam playerCam;
    public PlayerMovement player;

    [SerializeField] public Image fadeImage;
    public void bathroomFade()
    {
        FadeNoScene();
    }

    public void FadeNoScene(float fadeOutTime = 1f, float fadeInTime = 1f)
    {
        StartCoroutine(FadeRoutineNoScene(fadeOutTime, fadeInTime));
    }

    private IEnumerator FadeRoutineNoScene(float fadeOutTime, float fadeInTime)
    {
        float playerSenX = playerCam.sensX;
        float playerSenY = playerCam.sensY;

        player.moveSpeed = 0;

        playerCam.sensX = 0;
        playerCam.sensY = 0;
        yield return Fade(0f, 1f, fadeOutTime);

        yield return null; // wait one frame so the new scene loads

        yield return Fade(1f, 0f, fadeInTime);
        playerCam.sensX = playerSenX;
        playerCam.sensY = playerSenY;

        player.moveSpeed = 3;
    }

    public IEnumerator Fade(float from, float to, float duration)
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
