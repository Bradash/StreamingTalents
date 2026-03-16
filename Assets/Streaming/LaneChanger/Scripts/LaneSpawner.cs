using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer = 3f;
    float currentTime = 0f;

    public float startTime;

    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject[] spawns;
    [SerializeField] GameObject[] targets;

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
            GameObject obstacle1;
            GameObject obstacle2;

            switch (randomSpawn)
            {
                case 1:
                    obstacle1 = Instantiate(obstacle, spawns[0].transform.position, spawns[0].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[0].transform.position);
                    break;
                case 2:
                    obstacle1 = Instantiate(obstacle, spawns[1].transform.position, spawns[1].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[1].transform.position);
                    break;
                case 3:
                    obstacle1 = Instantiate(obstacle, spawns[2].transform.position, spawns[2].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[2].transform.position);
                    break;
                case 4:
                    obstacle1 = Instantiate(obstacle, spawns[0].transform.position, spawns[0].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[0].transform.position);
                    obstacle2 = Instantiate(obstacle, spawns[1].transform.position, spawns[1].transform.rotation);
                    obstacle2.GetComponent<LaneObjects>().SetTarget(targets[1].transform.position);
                    break;
                case 5:
                    obstacle1 = Instantiate(obstacle, spawns[0].transform.position, spawns[0].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[0].transform.position);
                    obstacle2 = Instantiate(obstacle, spawns[2].transform.position, spawns[2].transform.rotation);
                    obstacle2.GetComponent<LaneObjects>().SetTarget(targets[2].transform.position);
                    break;
                case 6:
                    obstacle1 = Instantiate(obstacle, spawns[1].transform.position, spawns[1].transform.rotation);
                    obstacle1.GetComponent<LaneObjects>().SetTarget(targets[1].transform.position);
                    obstacle2 = Instantiate(obstacle, spawns[2].transform.position, spawns[2].transform.rotation);
                    obstacle2.GetComponent<LaneObjects>().SetTarget(targets[2].transform.position);
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
