using UnityEngine;
using System.Collections;

public class VisualTiming : MonoBehaviour
{
    [SerializeField] Sprite[] timingSprites;
    SpriteRenderer timingSpriteRenderer;

    private void Start()
    {
        timingSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartTimingVisual(int timing)
    {
        StartCoroutine(SpawnTiming(timing));
    }

    IEnumerator SpawnTiming(int timing)
    {
        timingSpriteRenderer.sprite = timingSprites[timing];
        yield return new WaitForSeconds(0.5f);
        timingSpriteRenderer.sprite = null;
    }
}
