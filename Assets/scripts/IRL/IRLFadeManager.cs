using System.Collections;
using UnityEngine;

public class IRLFadeManager : FadeManager
{
    public PlayerCam playerCam;
    public PlayerMovement player;
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

}
