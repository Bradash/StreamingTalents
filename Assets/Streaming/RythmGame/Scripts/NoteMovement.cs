using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField] float noteSpeed = 4f;
    [SerializeField] float leftLaneX = -2.25f;

    private void Start()
    {
        NoteTiming script = gameObject.GetComponent<NoteTiming>();

        Vector3 offset = transform.localPosition;
        offset.x = leftLaneX + (1.5f * script.noteLane);
        transform.localPosition = offset;
    }

    private void Update()
    {
        float yPos = transform.position.y;
        yPos -= noteSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        if (yPos < -6)
        {
            Destroy(gameObject);
        }
    }
}
