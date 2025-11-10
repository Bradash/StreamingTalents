using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public string objectDescription;
    public bool objectHighlight;
    private MeshRenderer objectRenderer;
    private float currentTime;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<MeshRenderer>();
        currentTime = Mathf.PI;
        objectRenderer.material.EnableKeyword("_EMISSION");
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
            
        }
    }
    public void highlight()
    {
            currentTime += Time.deltaTime * 5f;
            Color highlight = new Color(Mathf.Cos(currentTime)/2 + 0.5f, Mathf.Cos(currentTime)/2 + 0.5f, 0);
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
