using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    [SerializeField] int noteLane;
    string[] zone = new string[5];
    string currentZone;
    [SerializeField] SpriteRenderer noteColor;

    private void Start()
    {
        zone[0] = "Miss";
        zone[1] = "Bad";
        zone[2] = "Okay";
        zone[3] = "Good";
        zone[4] = "Perfect";

        currentZone = zone[0];

        switch (noteLane)
        {
            case 0:
                noteColor.color = new Color32(130, 207, 255, 255);
                break;
            case 1:
                noteColor.color = new Color32(255, 127, 227, 255);
                break;
            case 2:
                noteColor.color = new Color32(255, 177, 128, 255);
                break;
            case 3:
                noteColor.color = new Color32(155, 255, 125, 255);
                break;
        }
    }

    private void Update()
    {
        switch (noteLane)
        {
            case 0:
                if(Input.GetKeyDown(KeyCode.A)) {
                    HitZone();
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    HitZone();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    HitZone();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    HitZone();
                }
                break;
        }

        if (transform.position.y < -4.7)
        {
            currentZone = zone[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == zone[1])
        {
            currentZone = zone[1];
        }
        else if (collision.tag == zone[2])
        {
            currentZone = zone[2];
        }
        else if (collision.tag == zone[3])
        {
            currentZone = zone[3];
        }
        else
        {
            currentZone = zone[4];
        }
    }

    void HitZone()
    {
        if (currentZone == zone[0]) //miss
        {
            Debug.Log("MISSED");
        } 
        else if (currentZone == zone[1]) //bad
        {
            Debug.Log("HIT BAD");
            Destroy(gameObject);
        } 
        else if (currentZone == zone[2]) //okay
        {
            Debug.Log("HIT OKAY");
            Destroy(gameObject);
        } 
        else if (currentZone == zone[3]) //good
        {
            Debug.Log("HIT GOOD");
            Destroy(gameObject);
        } 
        else //perfect
        {
            Debug.Log("HIT PERFECT");
            Destroy(gameObject);
        }
    }
}
