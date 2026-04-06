using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifcation : MonoBehaviour
{

    public List<TextingThread> allThreads;

    public GameObject managerNote;
    public GameObject wolfNote;
    public GameObject unicornNote;
    public GameObject dragonNote;
    public GameObject companyNote;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        yield return null; // wait one frame

        allThreads = TextSpawner.Instance.allThreads;

        int currentDay = GameManager.currentday;
        string currentCharacter = "null";

        //managerNote.SetActive(false);
        //wolfNote.SetActive(false);
        //unicornNote.SetActive(false);
        //dragonNote.SetActive(false);
        //companyNote.SetActive(false);


        currentCharacter = "Boss";
        foreach (TextingThread thread in allThreads)
        {
            //Debug.Log(thread.day + " " + currentDay + " " + thread.participants.name + " " +currentCharacter);
            // Check if both conditions match
            if (thread.day == currentDay && thread.participants.name == currentCharacter)
            {
                Debug.Log("Yep");
                if (thread.startingMessage != null)
                {
                    managerNote.SetActive(true);
                }
                else
                {
                    managerNote.SetActive(false);
                }
            }
        }

        currentCharacter = "Desmond";
        foreach (TextingThread thread in allThreads)
        {
            //Debug.Log(thread.participants.name);
            // Check if both conditions match
            if (thread.day == currentDay && thread.participants.name == currentCharacter)
            {
                Debug.Log("Yep");
                if (thread.startingMessage != null)
                {
                    wolfNote.SetActive(true);
                }
                else
                {
                    wolfNote.SetActive(false);
                }
            }
        }

        currentCharacter = "Ada";
        foreach (TextingThread thread in allThreads)
        {
            //Debug.Log(thread.participants.name);
            // Check if both conditions match
            if (thread.day == currentDay && thread.participants.name == currentCharacter)
            {
                Debug.Log("Yep");
                if (thread.startingMessage != null)
                {
                    unicornNote.SetActive(true);
                }
                else
                {
                    unicornNote.SetActive(false);
                }
            }
        }

        currentCharacter = "Ember";
        foreach (TextingThread thread in allThreads)
        {
            //Debug.Log(thread.participants.name);
            // Check if both conditions match
            if (thread.day == currentDay && thread.participants.name == currentCharacter)
            {
                Debug.Log("Yep");
                if (thread.startingMessage != null)
                {
                    dragonNote.SetActive(true);
                }
                else
                {
                    dragonNote.SetActive(false);
                }
            }
        }

        currentCharacter = "GC";
        foreach (TextingThread thread in allThreads)
        {
            //Debug.Log(thread.participants.name);
            // Check if both conditions match
            if (thread.day == currentDay && thread.participants.name == currentCharacter)
            {
                Debug.Log("Yep");
                if (thread.startingMessage != null)
                {
                    companyNote.SetActive(true);
                }
                else
                {
                    companyNote.SetActive(false);
                }
            }
        }
    }
}
