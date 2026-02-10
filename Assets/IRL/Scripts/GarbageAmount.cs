using UnityEngine;

public class GarbageAmount : MonoBehaviour
{
    public GameObject[] garbages;
    void Start()
    {
        int Day = loadDay();
        if (Day > garbages.Length) Day = garbages.Length;
        for(int i = 0; i < Day; i++)
        {
            garbages[i].SetActive(true);
        }
    }
    public int loadDay()
    {
        return GameManager.currentday;
    }
}
