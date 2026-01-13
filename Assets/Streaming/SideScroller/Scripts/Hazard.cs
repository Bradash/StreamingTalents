using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    float speed;
    GameObject hazardSpawner;

    void Start()
    {
        hazardSpawner = GameObject.Find("HazardSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        speed = hazardSpawner.GetComponent<HazardSpawner>().enemySpeed;

        Vector3 currentPos = transform.position;
        currentPos.x -= speed * Time.deltaTime;
        transform.position = currentPos;
    }

    void DeleteObject()
    {
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
