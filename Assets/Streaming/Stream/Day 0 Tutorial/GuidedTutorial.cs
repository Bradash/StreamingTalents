using UnityEngine;

public class GuidedTutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialObjects;
    [SerializeField] private int dayTaught;
    private int currentTutorial;

    private void Start()
    {
        if (GameManager.currentday == dayTaught)
        {
            GameManager.isTutorial = true;
            FadeManager.Instance.gameObject.SetActive(false);
            Time.timeScale = 0;
            MessageSpawner.Instance.pause = true;
            currentTutorial = 0;
            tutorialNext();
        }
    }
    public void tutorialNext()
    {
        if(currentTutorial > 0)
        {
            tutorialObjects[currentTutorial - 1].gameObject.SetActive(false);
            //Disable previous tutorial
        }
        if (currentTutorial < tutorialObjects.Length)
        {
            tutorialObjects[currentTutorial].gameObject.SetActive(true);
            currentTutorial++;
            //Enable next tutorial
        }
        else
        {
            Debug.Log("Sent");
            GameManager.isTutorial = false;
            FadeManager.Instance.gameObject.SetActive(true);
            FadeManager.Instance.fadeImage.color = new Color(0, 0, 0, 0);
            Time.timeScale = 1;
            MessageSpawner.Instance.pause = false;
        }
    }
}
