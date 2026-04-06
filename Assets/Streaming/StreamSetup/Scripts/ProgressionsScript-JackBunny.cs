using UnityEngine;

public class ProgressionsScript : MonoBehaviour
{
    [SerializeField] ElementSelection CollabChoices;
    [SerializeField] ElementSelection GameChoices;
    [SerializeField] SelectionObject[] CollabObjects;
    [SerializeField] SelectionObject[] GameObjects;

    public GameObject CollabNote1;
    public GameObject CollabNote2;
    public GameObject GameNote1;
    public GameObject GameNote2;

    private void Start()
    {
        addCSelections();
        addGSelections();
    }

    private void Awake()
    {
        CollabNote1.SetActive(false);
        CollabNote2.SetActive(false);
        GameNote1.SetActive(false);
        GameNote2.SetActive(false);
        
        if (GameManager.currentday == 2)
        {
            CollabNote1.SetActive(true);
            CollabNote2.SetActive(true);
            GameNote1.SetActive(true);
            GameNote2.SetActive(true);
        }
        if (GameManager.currentday == 3)
        {
            GameNote1.SetActive(true);
            GameNote2.SetActive(true);
        }
        if (GameManager.currentday == 4)
        {
            CollabNote1.SetActive(true);
            CollabNote2.SetActive(true);
        }
        if (GameManager.currentday == 6)
        {
            GameNote1.SetActive(true);
            GameNote2.SetActive(true);
        }
    }

    public void addCSelections()
    {
        for (int i = 0; i < CollabObjects.Length; i++)
        {
            if (CollabObjects[i].dayUnlocked <= GameManager.currentday)
            {
                CollabChoices.elementName.Add(CollabObjects[i].elementName);
                CollabChoices.elementImage.Add(CollabObjects[i].elementImage);
                CollabChoices.gameID.Add(CollabObjects[i].gameID);
            }
        }
    }
    public void addGSelections()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].dayUnlocked <= GameManager.currentday)
            {
                GameChoices.elementName.Add(GameObjects[i].elementName);
                GameChoices.elementImage.Add(GameObjects[i].elementImage);
                GameChoices.gameID.Add(GameObjects[i].gameID);
            }
        }
    }
}
