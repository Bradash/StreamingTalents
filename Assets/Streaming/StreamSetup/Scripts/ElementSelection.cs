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
        nameText.text = elementName[0];
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

        SceneManager.LoadScene("Stream View");
    }
}
