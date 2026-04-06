using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    float speed;
    HazardSpawner hazardSpawner;

    void Start()
    {
        hazardSpawner = GameObject.Find("HazardSpawner").GetComponent<HazardSpawner>();
        Player.resetGameState += DeleteObject;
    }

    // Update is called once per frame
    void Update()
    {
        speed = hazardSpawner.enemySpeed;

        Vector3 currentPos = transform.position;
        currentPos.x -= speed * Time.deltaTime;
        transform.position = currentPos;

        if (transform.position.x < -11)
        {
            DeleteObject();
        }
    }

    void DeleteObject()
    {
        Player.resetGameState -= DeleteObject;
        Destroy(this.gameObject);
    }
}
