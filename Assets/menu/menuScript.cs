using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Button loadButton;

    void Start()
    {
        if (!SaveSystem.SaveExists())
        {
            loadButton.interactable = false;
        }
    }

    public void NewGame()
    {
        SaveSystem.DeleteSave();

        GameManager.currentday = 0;
        GameManager.currentmoney = 0;
        GameManager.unicornRelationship = 0;
        GameManager.dragonRelationship = 0;
        GameManager.wolfRelationship = 0;

        FadeManager.Instance.FadeAndLoadScene("IRL");
    }

    public void LoadGame()
    {
        SaveSystem.LoadGame();
        FadeManager.Instance.FadeAndLoadScene("IRL");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}