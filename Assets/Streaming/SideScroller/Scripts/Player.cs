using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float speed = 7.5f;
    int direction = -1;
    float score;

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        
        Vector3 currentPos = transform.position;
        currentPos.y += speed * direction * Time.deltaTime;
        transform.position = currentPos;

        score += Time.deltaTime * 5;
        scoreText.text = "SCORE: " + Mathf.Round(score).ToString();
    }

    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
