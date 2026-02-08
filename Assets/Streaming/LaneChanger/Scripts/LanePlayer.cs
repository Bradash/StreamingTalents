using UnityEngine;

public class LanePlayer : MonoBehaviour
{
    Vector3 initialPos;
    [SerializeField] Vector3[] lanePositions;
    Vector3 targetLane;
    int currentLane = 1;
    bool playerAlive = true;
    [SerializeField] GameObject gameOver;
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        gameOver.SetActive(false);
        initialPos = transform.position;
        targetLane = lanePositions[currentLane];
        transform.position = lanePositions[currentLane];

        LaneSpawner.resetGameState += ResetState;
    }

    void Update()
    {
        if (playerAlive)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                currentLane = Mathf.Clamp(currentLane + 1, 0, 2);
                targetLane = lanePositions[currentLane];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                currentLane = Mathf.Clamp(currentLane - 1, 0, 2);
                targetLane = lanePositions[currentLane];
            }

            Movement();
        }
    }

    void Movement()
    {
        if (playerAlive)
        {
            Vector3 pos = transform.position;
            if (Mathf.Abs(targetLane.x - pos.x) > 0.1f)
            {
                float direction = Mathf.Sign(targetLane.x - pos.x);
                pos.x += moveSpeed * Time.deltaTime * direction;
                transform.position = pos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerAlive = false;
        Vector3 pos = transform.position;
        pos.y -= 100;
        transform.position = pos;
        gameOver.SetActive(true);
    }

   void ResetState()
    {
        gameOver.SetActive(false);
        transform.position = initialPos;
        currentLane = 1;
        targetLane = lanePositions[currentLane];
        playerAlive = true;
    }
}
