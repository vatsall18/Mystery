using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class KeyLockOpener : MonoBehaviour
{
    [Tooltip("Your closet's Animator")]
    public Animator closetAnimator;
    [Tooltip("Trigger parameter name to open it")]
    public string openTrigger = "Open";

    XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(_ => Unlock());
    }

    void OnDestroy()
    {
        socket.selectEntered.RemoveListener(_ => Unlock());
    }

    void Unlock()
    {
        closetAnimator.SetTrigger(openTrigger);
        socket.enabled = false; // optional: only unlock once
    }
}
