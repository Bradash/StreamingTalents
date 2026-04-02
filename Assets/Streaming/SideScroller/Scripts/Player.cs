using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tutorialText;

    public float speed = 5f;
    int direction = -1;
    float score;
    bool isAlive = true;
    Vector3 initialPos;

    bool canMove = false;
    public float startDelay = 1f;

    [SerializeField] GameObject gameOver;

    public delegate void ResetGameState();
    public static event ResetGameState resetGameState;

    private void Start()
    {
        tutorialText.enabled = true;
        initialPos = transform.position;
        StartCoroutine(LockMovement());
    }

    void Update()
    {
        if (isAlive && canMove)
        {
            PlayerInput();

            Vector3 currentPos = transform.position;
            currentPos.y += speed * direction * Time.deltaTime;
            currentPos.y = Mathf.Clamp(currentPos.y, -2f, 4.5f);
            transform.position = currentPos;

            if (score >= 50)
            {
                tutorialText.enabled = false;
            }

            score += Time.deltaTime * 5;
            scoreText.text = "SCORE: " + Mathf.Round(score).ToString();

            if (isAlive)
            {
                UIStatsManager.Instance.points = score * 2;
            }
        }

        if(!isAlive && Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
            isAlive = true;
        }
    }

    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
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
        resetGameState?.Invoke();
        transform.position = initialPos;
        score = 0;
        direction = -1;
        isAlive = true;
        canMove = false;
        gameOver.SetActive(false);
        StartCoroutine(LockMovement());
    }

    IEnumerator LockMovement()
    {
        yield return new WaitForSeconds(startDelay);
        canMove = true;
    }
}
