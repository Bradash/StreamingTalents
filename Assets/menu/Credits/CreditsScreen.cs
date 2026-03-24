using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        FadeManager.Instance.FadeAndLoadScene("menu");
        }
    }
}
