using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void LoadScene(string sceneName)
    {
        Debug.Log("Testing");
        if (sceneName == "IRL")
        {
            if (GameManager.currentday == 15)
            {
                if (GameManager.currentday == 20)
                {
                    SaveSystem.SaveGame();

                    GameManager.currentday += 1;
                    print("Finish");
                    GameManager.currentday = 0;
                    FadeManager.Instance.FadeAndLoadScene("menu");
                }
                else
                {
                    SaveSystem.SaveGame();

                    GameManager.currentday += 1;
                    print("End Game");
                    GameManager.currentday = 20;
                    FadeManager.Instance.FadeAndLoadScene("Stream Results");
                } 
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
