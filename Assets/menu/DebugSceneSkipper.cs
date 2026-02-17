using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneSkipper : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextScene();
        }
#endif
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
