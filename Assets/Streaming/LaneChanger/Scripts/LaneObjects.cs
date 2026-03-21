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
    Vector3 currentTarget;

    private void Start()
    {
        spawner = GameObject.Find("Spawns").GetComponent<LaneSpawner>();
        startTime = spawner.GetStartTime();

        LaneSpawner.resetGameState += ResetObects;
    }
    void Update()
    {
        currentTime = Time.time - startTime;
        if (!maxSpeed)
        {
            if (objectSpeed < initialSpeed + 10)
            {
                objectSpeed = initialSpeed + currentTime;
            }
            else
            {
                objectSpeed = initialSpeed + 10;
                maxSpeed = true;
            }
        }
        Vector3 direction = (currentTarget - transform.position).normalized;
        transform.position += direction * objectSpeed * Time.deltaTime;

        if (transform.position.z < -450)
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

    public void SetTarget(Vector3 target)
    {
        currentTarget = target;
    }
}
