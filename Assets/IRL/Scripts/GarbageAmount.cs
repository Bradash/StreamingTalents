using UnityEngine;

public class GarbageAmount : MonoBehaviour
{
    public int Day;
    public GameObject[] garbages;
    void Start()
    {
        if(Day > garbages.Length) Day = garbages.Length;
        for(int i = 0; i < Day; i++)
        {
            garbages[i].SetActive(true);
        }
    }
}
