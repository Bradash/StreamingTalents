using NUnit.Framework.Interfaces;
using UnityEngine;

public class LaneObjects : MonoBehaviour
{
    float objectSpeed;
    float startTime;
    [SerializeField] float initialSpeed = 5f;
    LaneSpawner spawner;
    float currentTime;
    bool maxSpeed = false;

    private void Start()
    {
        spawner = GameObject.Find("Spawns").GetComponent<LaneSpawner>();
        startTime = spawner.GetStartTime();

        if (objectSpeed < initialSpeed + 10)
        {
            objectSpeed = initialSpeed + Time.time * 0.5f;
        }
        else
        {
            objectSpeed = 15;
        }

        LaneSpawner.resetGameState += ResetObects;
    }
    void Update()
    {
        currentTime = Time.time - startTime;
        if (!maxSpeed)
        {
            if (objectSpeed < initialSpeed + 50)
            {
                objectSpeed = initialSpeed + currentTime;
            }
            else
            {
                objectSpeed = initialSpeed + 50;
                maxSpeed = true;
            }
        }
        float zPos = transform.position.z;
        zPos -= objectSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);

        if (zPos < -10)
        {
            Destroy(gameObject);
        }
    }

    void ResetObects()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        LaneSpawner.resetGameState -= ResetObects;
    }
}
