using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public float enemySpeed = 5f;
    public List<GameObject> hazards;

    public float spawnDelay = 2f;
    float spawnTimer = 0f;
    int difficulty = 1;

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        enemySpeed += 0.1f * Time.deltaTime;

        if (spawnTimer < 0)
        {
            Instantiate(hazards[(int)Random.Range(0, hazards.Count)], new Vector3(transform.position.x, Random.Range(-3f, 3f), transform.position.z), Quaternion.identity);
            spawnTimer = spawnDelay;
            if (difficulty < 20)
            {
                difficulty++;
                spawnDelay -= 0.05f;
            }
        }
    }
}
