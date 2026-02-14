using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName == "MainGame")
        {
            if (GameManager.currentday == 3)
            {
                GameManager.currentday += 1;
                print("End Game");
                SceneManager.LoadScene(0);
            }
            else
            {
                GameManager.currentday += 1;
                print("Day update");
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
