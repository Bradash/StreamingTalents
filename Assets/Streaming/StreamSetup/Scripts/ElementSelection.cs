using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementSelection : MonoBehaviour
{
    public List<string> elementName = new List<string>();
    public List<Sprite> elementImage = new List<Sprite>();
    public List<int> gameID;
    int currentElement = 0;
    public int selectionType; //1 = collab, 2 = game

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Sprite image;

    [SerializeField] GameObject IMG_Image;

    void Start()
    {
        startingElement();
    }

    public void NextElement()
    {
        currentElement = (currentElement + 1) % elementName.Count;
        nameText.text = elementName[currentElement];
        IMG_Image.GetComponent<Image>().sprite = elementImage[currentElement];
        Debug.Log($"current element: {currentElement}");
    }

    public void PrevElement()
    {
        {
            if (currentElement > 0)
            {
                currentElement = (currentElement - 1) % elementName.Count;
            }
            else
            {
                currentElement = elementName.Count - 1;
            }

            nameText.text = elementName[currentElement];
            IMG_Image.GetComponent<Image>().sprite = elementImage[currentElement];
            Debug.Log($"current element: {currentElement}");
        }
    }

    public void StartGame()
    {
        if (selectionType == 2)
        {
            GameManager.SelectedMinigame = gameID[currentElement];
            print("Game" + GameManager.SelectedMinigame);
        }
        if (selectionType == 1)
        {
            GameManager.SelectedCollab = gameID[currentElement];
            print("Collab " + GameManager.SelectedCollab);
        }

        FadeManager.Instance.FadeAndLoadScene("Stream View");
    }

    public void startingElement()
    {
        if (GameManager.currentday == 2)
        {
            currentElement = 1;
            nameText.text = elementName[1];
            IMG_Image.GetComponent<Image>().sprite = elementImage[1];
        }
        else
        {
            currentElement = 0;
            nameText.text = elementName[0];
            IMG_Image.GetComponent<Image>().sprite = elementImage[0];
        }

        //This is here because for other days you don't get to pick we want to start on that element.
    }
}