using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public float enemySpeed = 2.5f;
    public List<GameObject> hazards;

    public float spawnDelay = 3.5f;
    float spawnTimer = 0.5f;
    int difficulty = 1;

    public delegate void ResetGameState();
    public static event ResetGameState resetGameState;

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (enemySpeed < 10f)
        {
            enemySpeed += 0.25f * Time.deltaTime;
        }

        if (spawnTimer < 0)
        {
            Instantiate(hazards[(int)Random.Range(0, hazards.Count)], new Vector3(transform.position.x, transform.position.y + Random.Range(-2.5f, 2.5f), transform.position.z), Quaternion.identity);
            spawnTimer = spawnDelay;
            if (difficulty < 20)
            {
                difficulty++;
                spawnDelay -= 0.025f;
            }
        }
    }

    public void RestartGame()
    {
        resetGameState?.Invoke();
        enemySpeed = 2.5f;
        spawnDelay = 3.5f;
        spawnTimer = 0.5f;
        difficulty = 1;
    }
}
