using System;
using Unity.VisualScripting;
using UnityEngine;

public class NoteTriggers : MonoBehaviour
{
    //IMPORTANT EXAPLE OF POINTS: UIStatsManager.Instance.points += 5; (MIN: 0, MAX: 100, DEFAULT: 50)

    [SerializeField] GameObject timingIcon;
    VisualTiming timingScript;
    public int notesInZone = 0;
    [SerializeField] int lane;

    private void Start()
    {
        timingScript = timingIcon.GetComponent<VisualTiming>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            notesInZone++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            notesInZone--;
        }
    }

    private void Update()
    {
        if (notesInZone <= 0)
        {
            switch (lane)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        //Debug.Log("MISSED");
                        Debug.Log($"Note Time: {Time.time} \nNote Y-Pos: {(3*Time.time) - 3.9}");
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        //Debug.Log("MISSED");
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        //Debug.Log("MISSED");
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        //Debug.Log("MISSED");
                    }
                    break;
            }
        }
    }
}
