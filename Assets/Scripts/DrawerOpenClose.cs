using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class DrawerOpenClose : MonoBehaviour
{
    [Tooltip("How far to slide the drawer out along its local Z")]
    public float openZOffset = 0.2f;

    Vector3 closedPos;
    Vector3 openPos;
    bool isOpen = false;

    XRSimpleInteractable simpleInt;

    void Awake()
    {
        // Cache positions
        closedPos = transform.localPosition;
        openPos = closedPos + Vector3.forward * openZOffset;

        // Grab our Interactable
        simpleInt = GetComponent<XRSimpleInteractable>();
        simpleInt.selectEntered.AddListener(OnFirstSelectEntered);
    }

    void OnDestroy()
    {
        simpleInt.selectEntered.RemoveListener(OnFirstSelectEntered);
    }

    private void OnFirstSelectEntered(SelectEnterEventArgs args)
    {
        // Toggle open/closed
        isOpen = !isOpen;
        transform.localPosition = isOpen ? openPos : closedPos;

        // If we just opened it, disable further interaction
        if (isOpen)
            simpleInt.enabled = false;
    }
}
