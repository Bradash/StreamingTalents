using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;
    float pickupDistance = 2f;
    private ObjectGrabbable objectGrabbable;
    private ObjectGrabbable objectHighlight;
    private bool wasHit;
    private bool isGrabbed;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (objectGrabbable == null) 
            {
                
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        isGrabbed = true;
                        objectGrabbable.unhighlight();
                        TextMeshProUGUI.text = objectGrabbable.objectDescription;
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                isGrabbed = false;
                objectGrabbable.Drop();
                objectGrabbable = null;
                TextMeshProUGUI.text = null;
            }

        }
        else
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask) && !isGrabbed)
            {
                if (raycastHit.transform.TryGetComponent(out objectHighlight))
                {
                    objectHighlight.highlight();
                    wasHit = true;
                }
            }
            else if (wasHit == true)
            {
                objectHighlight.unhighlight();
                objectHighlight = null;
                wasHit = false;
            }
        }
    }
}
