using UnityEngine;
using UnityEngine.Android;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public string objectDescription;
    public bool objectHighlight;
    private MeshRenderer objectRenderer;
    private float currentTime;
    public bool nonGrabbable;
    public bool interactOnce;
    public bool interacted;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<MeshRenderer>();
        currentTime = Mathf.PI;

        foreach (Material mat in objectRenderer.materials)
        {
            mat.EnableKeyword("_EMISSION");
        }     
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
    public void Interact()
    {
        if (interactOnce && !interacted)
        {
            interacted = true;
        }
     
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
        foreach (Material mat in objectRenderer.materials)
        {
            mat.SetColor("_EmissionColor", highlight);
            mat.EnableKeyword("_EMMISION");
        }
        
    }
    public void unhighlight()
    {
        foreach (Material mat in objectRenderer.materials)
        {
            mat.DisableKeyword("_EMMISION");
            mat.SetColor("_EmissionColor", Color.black);
        }
            currentTime = Mathf.PI;
    }
}
