using UnityEngine;

public class StreamLogic : MonoBehaviour
{
    public int streamstate; //0 = null, 1 = pre-stream, 2 = loading stream, 3 = streaming, 4 = post stream, 5 = other scene
    public int narrativeState;
    public narrativeState gameState;

    //To be converted later
    int day = 1;
    float money;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        streamstate = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (day == 1)
        {
            narrativeState = 1;
            gameState.narState = narrativeState;
        }
    }
}
