using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer = 3f;
    float currentTime = 0f;

    public float startTime;

    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject[] spawns;

    public delegate void ResetGameState();
    public static event ResetGameState resetGameState;

    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            int randomSpawn = Random.Range(1, 7);
            Debug.Log(randomSpawn);

            switch(randomSpawn)
            {
                case 1:
                    Instantiate(obstacle, spawns[0].transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(obstacle, spawns[1].transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(obstacle, spawns[2].transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(obstacle, spawns[0].transform.position, Quaternion.identity);
                    Instantiate(obstacle, spawns[1].transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(obstacle, spawns[0].transform.position, Quaternion.identity);
                    Instantiate(obstacle, spawns[2].transform.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(obstacle, spawns[1].transform.position, Quaternion.identity);
                    Instantiate(obstacle, spawns[2].transform.position, Quaternion.identity);
                    break;
            }

            currentTime = spawnTimer;
            if (spawnTimer > 1)
            {
                spawnTimer -= 0.25f;
            }
        }
    }

    public float GetStartTime()
    {
        return startTime;
    }

    public void ResetGame()
    {
        resetGameState?.Invoke();
        startTime = Time.time;
        spawnTimer = 3f;
        currentTime = 0f;
    }
}
