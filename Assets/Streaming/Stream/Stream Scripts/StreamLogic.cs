using UnityEngine;

public class StreamLogic : MonoBehaviour
{
    public int streamstate; //0 = null, 1 = pre-stream, 2 = loading stream, 3 = streaming, 4 = post stream, 5 = other scene

    //To be converted later
    int day;
    float money;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        streamstate = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
