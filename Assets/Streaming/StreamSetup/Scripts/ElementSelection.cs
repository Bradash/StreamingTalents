using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElementSelection : MonoBehaviour
{
    [SerializeField] List<string> elementName = new List<string>();
    [SerializeField] List<Sprite> elementImage = new List<Sprite>();
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
        bool allowed = dayCheck();
        if (allowed)
        {
            currentElement = (currentElement + 1) % elementName.Count;
            nameText.text = elementName[currentElement];
            IMG_Image.GetComponent<Image>().sprite = elementImage[currentElement];
            Debug.Log($"current element: {currentElement}");
        }
    }

    public void PrevElement()
    {
        bool allowed = dayCheck();
        if (allowed)
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
            GameManager.SelectedMinigame = currentElement;
            print("Game" + GameManager.SelectedMinigame);
        }
        if (selectionType == 1)
        {
            GameManager.SelectedCollab = currentElement;
            print("Collab " + GameManager.SelectedCollab);
        }

        FadeManager.Instance.FadeAndLoadScene("Stream View");
    }

    public bool dayCheck()
    {
        //Check the current element and day, see if it's allowed to change
        if (GameManager.currentday == 1)
        {
            return false;
        }
        else
        {
            return true;
        }

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
