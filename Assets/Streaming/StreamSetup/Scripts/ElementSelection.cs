using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementSelection : MonoBehaviour
{
    [SerializeField] List<string> elementName = new List<string>();
    [SerializeField] List<Sprite> elementImage = new List<Sprite>();
    int currentElement = 0;
    public int selectionType; //1 = collab, 2 = game

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Sprite image;

    [SerializeField] GameObject IMG_Image;

    [SerializeField] GameObject BTN_Next;
    [SerializeField] GameObject BTN_Prev;

    bool allowed;

    void Start()
    {
        startingElement();
    }

    private void Awake()
    {
        allowed = dayCheck();

        if (!allowed)
        {
            BTN_Next.SetActive(false);
            BTN_Prev.SetActive(false);
            IMG_Image.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        else
        {
            BTN_Next.SetActive(true);
            BTN_Prev.SetActive(true);
            IMG_Image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void NextElement()
    {
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
