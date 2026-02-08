using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField] float noteSpeed = 3f;
    string[] zone = new string[4];

    private void Start()
    {
        zone[0] = "Bad";
        zone[1] = "Okay";
        zone[2] = "Good";
        zone[3] = "Perfect";
    }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        //JUST TESTING WITH 'W' KEY
        //MUST SET UP TO WORK WITH THEIR RESPECTIVE LANES
        //MUST SET A VARIABLE TO SEE WHAT ZONE THE PLAYER IS IN TO HANDLE INPUT IN FIXED UPDATE

        //if (collision.tag == zone[0])
        //    {
        //        Debug.Log("HIT BAD");
        //    } else if (collision.tag == zone[2])
        //    {
        //        Debug.Log("HIT OKAY");
        //    } else if (collision.tag == zone[3])
        //    {
        //        Debug.Log("HIT GOOD");
        //    } else
        //    {
        //        Debug.Log("HIT PERFECT");
        //    }
    }
}
