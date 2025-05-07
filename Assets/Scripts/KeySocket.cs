using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class KeyedDoorOpener : MonoBehaviour
{
    [Header("Drag your door Transform here")]
    public Transform door;

    [Header("Target local position/rotation when opened")]
    public Vector3 openLocalPosition = new Vector3(-0.19f, 0.1984f, -0.353f);
    public Vector3 openLocalEulerAngles = new Vector3(0f, 90f, 0f);

    XRSocketInteractor socket;
    bool hasOpened = false;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDestroy()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (hasOpened)
            return;

        // 1?? Open the door
        door.localPosition = openLocalPosition;
        door.localEulerAngles = openLocalEulerAngles;

        // 2?? Get the key GameObject
        var keyGO = args.interactableObject.transform.gameObject;

        // 3?? Parent & freeze the key in place
        //    (socket will already parent it under Attach Transform)
        var rb = keyGO.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // 4?? Disable the key?s grab so it can't be pulled back out
        var grab = keyGO.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab)
            grab.enabled = false;

        // 5?? Finally, prevent re-opening
        hasOpened = true;
        // (you can disable the socket here if you like)
        // socket.enabled = false;
    }
}
