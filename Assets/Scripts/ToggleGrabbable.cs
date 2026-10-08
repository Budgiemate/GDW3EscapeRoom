using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ToggleGrabbable : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void SetGrabbable(bool isGrabbable)
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = isGrabbable;
        }
    }
}