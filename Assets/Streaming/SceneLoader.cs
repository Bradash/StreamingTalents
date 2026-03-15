using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void LoadScene(string sceneName)
    {
        Debug.Log("Testing");
        if (sceneName == "IRL")
        {
            if (GameManager.currentday == 3)
            {
                SaveSystem.SaveGame();

                GameManager.currentday += 1;
                print("End Game");
                FadeManager.Instance.FadeAndLoadScene("menu");
            }
            else
            {
                GameManager.currentday += 1;

                SaveSystem.SaveGame();

                print("Day update");
                FadeManager.Instance.FadeAndLoadScene("IRL");
            }
        }
        else
        {
            FadeManager.Instance.FadeAndLoadScene(sceneName);
        }
    }
}
