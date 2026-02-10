using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] GameObject[] minigames;

    void Start()
    {
        for (int i = 0; i < minigames.Length; i++)
        {
            if (i == GameManager.SelectedMinigame)
            {
                minigames[i].SetActive(true);
            } else
            {
                minigames[i].SetActive(false);
            }
        }
    }
}
