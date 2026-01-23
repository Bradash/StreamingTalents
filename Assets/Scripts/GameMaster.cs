using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int quest1Progress;
    public void computerInteract()
    {
        if (quest1Progress <= 3)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        if (quest1Progress > 3)
        {
            string notification = "I need to make coffee and get food";
        }

    }
}
