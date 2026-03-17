using System.Linq;
using UnityEngine;

public class tutorialInteract : MonoBehaviour
{
    public BoxCollider colliderTutorial;
    public tutorialManager tutorialManage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.currentday == 1)
        {
            tutorialManage.playTutorial("Interaction", GameManager.tutorialList["Interaction"].Keys.First(), 7.5f, false);
        }
        colliderTutorial.gameObject.SetActive(false);

    }
}
