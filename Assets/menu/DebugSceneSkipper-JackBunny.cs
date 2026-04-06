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
            LoadNextScene();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.currentday -= 1;
            Debug.Log("Current day is: " + GameManager.currentday);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.currentday += 1;
            Debug.Log("Current day is: " + GameManager.currentday);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
