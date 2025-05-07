using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class DrawerOpenClose : MonoBehaviour
{
    public float openZOffset = 0.2f;

    Vector3 closedPos;
    Vector3 openPos;
    bool isOpen = false;

    XRSimpleInteractable simpleInt;
    Collider col;

    void Awake()
    {
        closedPos = transform.localPosition;
        openPos = closedPos + Vector3.forward * openZOffset;

        simpleInt = GetComponent<XRSimpleInteractable>();
        col = GetComponent<Collider>();
        simpleInt.selectEntered.AddListener(OnFirstSelectEntered);
    }

    void OnDestroy()
    {
        simpleInt.selectEntered.RemoveListener(OnFirstSelectEntered);
    }

    private void OnFirstSelectEntered(SelectEnterEventArgs args)
    {
        isOpen = !isOpen;
        transform.localPosition = isOpen ? openPos : closedPos;

        if (isOpen)
            simpleInt.enabled = false;
            col.enabled = false;
    }
}
