using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer = 5f;
    float currentTime = 0f;

    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject[] spawns;

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            int randomSpawn = Random.Range(0, spawns.Length);
            Instantiate(obstacle, spawns[randomSpawn].transform.position, Quaternion.identity);
            currentTime = spawnTimer;
            if(spawnTimer > 1)
            {
                spawnTimer -= 0.25f;
            }
        }
    }
}
