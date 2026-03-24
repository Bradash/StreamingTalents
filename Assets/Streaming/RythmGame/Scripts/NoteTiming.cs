using UnityEngine;
using System.Collections;

public class NoteTiming : MonoBehaviour
{
    [SerializeField] int noteLane;
    string[] zone = new string[5];
    string currentZone;
    [SerializeField] SpriteRenderer noteColor;
    [SerializeField] Sprite[] noteSprites;
    SpriteRenderer currentSprite;
    [SerializeField] GameObject noteIcon;
    [SerializeField] float missZone = -4.7f;
    GameObject timingIcon;
    VisualTiming timingScript;
    bool inZone = false;
    

    private void Start()
    {
        currentSprite = noteIcon.GetComponent<SpriteRenderer>();

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
                currentSprite.sprite = noteSprites[0];
                timingIcon = GameObject.Find("Timing1");
                break;
            case 1:
                noteColor.color = new Color32(255, 127, 227, 255);
                currentSprite.sprite = noteSprites[1];
                timingIcon = GameObject.Find("Timing2");
                break;
            case 2:
                noteColor.color = new Color32(255, 177, 128, 255);
                currentSprite.sprite = noteSprites[2];
                timingIcon = GameObject.Find("Timing3");
                break;
            case 3:
                noteColor.color = new Color32(155, 255, 125, 255);
                currentSprite.sprite = noteSprites[3];
                timingIcon = GameObject.Find("Timing4");
                break;
        }
        timingScript = timingIcon.GetComponent<VisualTiming>();
    }

    private void Update()
    {
        if (inZone)
        {
            switch (noteLane)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        HitZone();
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        HitZone();
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        HitZone();
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        HitZone();
                    }
                    break;
            }
        }

        if (inZone && transform.position.y < missZone)
        {
            inZone = false;
            currentZone = zone[0];
            HitZone();
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

        if(!inZone) { inZone = true; }
    }

    void HitZone()
    {
        if (currentZone == zone[0]) //miss
        {
            timingScript.StartTimingVisual(0);
            Debug.Log("MISSED");
        } 
        else if (currentZone == zone[1]) //bad
        {
            timingScript.StartTimingVisual(1);
            Debug.Log("HIT BAD");
            Destroy(gameObject);
        } 
        else if (currentZone == zone[2]) //okay
        {
            timingScript.StartTimingVisual(2);
            Debug.Log("HIT OKAY");
            Destroy(gameObject);
        } 
        else if (currentZone == zone[3]) //good
        {
            timingScript.StartTimingVisual(3);
            Debug.Log("HIT GOOD");
            Destroy(gameObject);
        } 
        else //perfect
        {
            timingScript.StartTimingVisual(4);
            Debug.Log("HIT PERFECT");
            Destroy(gameObject);
        }
    }
}
