using UnityEngine;

public class TycoonGameState : MonoBehaviour
{
    [SerializeField] GameObject exitUI;
    public void EnableUI(GameObject enable)
    {
        enable.SetActive(true);
    }

    public void DisableUI(GameObject disable)
    {
        disable.SetActive(false);
    }
}
