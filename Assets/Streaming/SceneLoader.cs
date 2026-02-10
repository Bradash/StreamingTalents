using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName == "MainGame")
        {
            GameManager.currentday += 1;
            print("Day update");
        }
        SceneManager.LoadScene(sceneName);
    }
}
