using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElementSelection : MonoBehaviour
{
    [SerializeField] List<string> elementName = new List<string>();
    [SerializeField] List<Image> elementImage = new List<Image>();
    int currentElement = 0;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image image;

    void Start()
    {
        nameText.text = elementName[0];
    }

    public void NextElement()
    {
        currentElement = (currentElement + 1) % elementName.Count;
        nameText.text = elementName[currentElement];
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
        Debug.Log($"current element: {currentElement}");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(elementName[currentElement]);
    }
}
