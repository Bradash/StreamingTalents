using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float speed = 7.5f;
    int direction = -1;
    float score;
    bool isAlive = true;
    Vector3 initialPos;

    [SerializeField] GameObject gameOver;

    private void Start()
    {
        initialPos = transform.position;
        HazardSpawner.resetGameState += ResetPlayer;
    }

    void Update()
    {
        if (isAlive)
        {
            PlayerInput();

            Vector3 currentPos = transform.position;
            currentPos.y += speed * direction * Time.deltaTime;
            transform.position = currentPos;

            score += Time.deltaTime * 5;
            scoreText.text = "SCORE: " + Mathf.Round(score).ToString();
        }
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
        isAlive = false;
        Vector3 pos = transform.position;
        pos.x -= 10;
        transform.position = pos;
        gameOver.SetActive(true);
    }

    void ResetPlayer()
    {
        transform.position = initialPos;
        score = 0;
        direction = -1;
        isAlive = true;
        gameOver.SetActive(false);
    }
}
