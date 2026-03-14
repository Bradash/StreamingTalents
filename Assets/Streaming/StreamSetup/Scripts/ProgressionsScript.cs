using UnityEngine;

public class ProgressionsScript : MonoBehaviour
{
    [SerializeField] ElementSelection CollabChoices;
    [SerializeField] ElementSelection GameChoices;
    [SerializeField] SelectionObject[] CollabObjects;
    [SerializeField] SelectionObject[] GameObjects;
    private void Start()
    {
        addCSelections();
        addGSelections();
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
