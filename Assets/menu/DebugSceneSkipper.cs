using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneSkipper : MonoBehaviour
{
    void Awake()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        int nextIndex = currentIndex + 1;

        if (nextIndex >= sceneCount)
        {
            nextIndex = 0;
        }

        SceneManager.LoadScene(nextIndex);
    }
}
