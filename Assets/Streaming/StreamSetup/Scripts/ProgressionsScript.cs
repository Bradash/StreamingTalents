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
                //CollabChoices.elementName.Add(CollabObjects[i].elementName);//Error
                //CollabChoices.elementImage.Add(CollabObjects[i].elementImage);//Error
                //CollabChoices.gameID.Add(CollabObjects[i].gameID);//Error
            }
        }
    }
    public void addGSelections()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].dayUnlocked <= GameManager.currentday)
            {
                //GameChoices.elementName.Add(GameObjects[i].elementName);//Error
                //GameChoices.elementImage.Add(GameObjects[i].elementImage);//Error
                //GameChoices.gameID.Add(GameObjects[i].gameID);//Error
            }
        }
    }
}
