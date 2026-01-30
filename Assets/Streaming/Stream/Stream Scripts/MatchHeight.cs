using UnityEngine;


public class MatchHeight : MonoBehaviour
{
    RectTransform source;
    RectTransform target;

    void Awake()
    {
        target = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (!source || !target) return;

        Vector2 size = target.sizeDelta;
        size.y = source.rect.height;
        target.sizeDelta = size;
    }
}
