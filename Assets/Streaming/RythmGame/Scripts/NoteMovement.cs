using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField] float noteSpeed = 3f;

    private void Update()
    {
        float yPos = transform.position.y;
        yPos -= noteSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        if(yPos < -6)
        {
            Destroy(gameObject);
        }
    }
}
