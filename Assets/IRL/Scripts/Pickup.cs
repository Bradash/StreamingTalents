using TMPro;
using Unity.VisualScripting;
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
    public GameMaster gameMaster;
    float time;
    bool timerOn;
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
                        if (!objectGrabbable.nonGrabbable)
                        {
                            isGrabbed = true;
                            objectGrabbable.unhighlight();
                            TextMeshProUGUI.text = objectGrabbable.objectDescription;
                            objectGrabbable.Grab(objectGrabPointTransform);
                        }
                        else
                        {
                            if (!objectGrabbable.interacted && objectGrabbable.interactOnce)
                            {
                                objectGrabbable.Interact();
                                gameMaster.quest1Progress++;
                                TextMeshProUGUI.text = objectGrabbable.objectDescription;
                                timerOn = true;
                                gameMaster.objectInteract();
                            }
                            if (!objectGrabbable.interactOnce)
                            {
                                gameMaster.computerInteract();
                                TextMeshProUGUI.text = gameMaster.questName;
                                timerOn = true;
                            }
                        }
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
        if (timerOn)
        {
            textTimer();
        }
    }
    void textTimer()
    {
        if(time < 2)
        {
            time += Time.deltaTime;
        }
        if(time >= 2)
        {
            objectGrabbable = null;
            TextMeshProUGUI.text = null;
            timerOn = false;
            time = 0;
        }
    }
}

