using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LanePlayer : MonoBehaviour
{
    [SerializeField] Vector3[] lanePositions;
    Vector3 targetLane;
    int currentLane = 1;

    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        targetLane = lanePositions[currentLane];
        transform.position = lanePositions[currentLane];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);
            targetLane = lanePositions[currentLane];
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);
            targetLane = lanePositions[currentLane];
        }

        Movement();
    }

    void Movement()
    {
        Vector3 pos = transform.position;
        if (Mathf.Abs(targetLane.x - pos.x) > 0.1f) {
            float direction = Mathf.Sign(targetLane.x - pos.x);
            pos.x += moveSpeed * Time.deltaTime * direction;
            transform.position = pos;
        }
    }
}
