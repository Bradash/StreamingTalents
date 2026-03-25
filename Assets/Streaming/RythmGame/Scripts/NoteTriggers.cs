using System;
using Unity.VisualScripting;
using UnityEngine;

public class NoteTriggers : MonoBehaviour
{
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
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        UIStatsManager.Instance.points -= 5;
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        UIStatsManager.Instance.points -= 5;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        UIStatsManager.Instance.points -= 5;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        timingScript.StartTimingVisual(0);
                        UIStatsManager.Instance.points -= 5;
                    }
                    break;
            }
        }
    }
}
