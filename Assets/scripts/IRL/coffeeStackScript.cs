using UnityEngine;

public class coffeeStackScript : MonoBehaviour
{
    public GameObject[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int coffees = 0; coffees < GameManager.currentday; coffees++)
        {
            gameObjects[coffees].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
