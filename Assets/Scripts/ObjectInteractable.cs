using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    GameObject quitUI;
    public bool objectHighlight;
    private MeshRenderer objectRenderer;
    private float currentTime;
    private void Awake()
    {
        objectRenderer = GetComponent<MeshRenderer>();
        currentTime = Mathf.PI;
        objectRenderer.material.EnableKeyword("_EMISSION");
    }
    public void quitPopUp()
    {
        quitUI.SetActive(true);
    }
    public void closePopUp()
    {
        quitUI.SetActive(false);
    }
    public void acceptPopUp()
    {
        Application.Quit();
    }
    public void highlight()
    {
        currentTime += Time.deltaTime * 5f;
        Color highlight = new Color(Mathf.Cos(currentTime) / 2 + 0.5f, Mathf.Cos(currentTime) / 2 + 0.5f, 0);
        objectRenderer.material.SetColor("_EmissionColor", highlight);
        objectRenderer.material.EnableKeyword("_EMMISION");
        Debug.Log(highlight);
    }
    public void unhighlight()
    {
        objectRenderer.material.DisableKeyword("_EMMISION");
        objectRenderer.material.SetColor("_EmissionColor", Color.black);
        currentTime = Mathf.PI;
    }
}
