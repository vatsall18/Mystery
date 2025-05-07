using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class LightSwitch : MonoBehaviour
{
    public GameObject lightsRoot;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    private Light[] lights;
    private bool isOn = true;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        lights = lightsRoot.GetComponentsInChildren<Light>(true);
        interactable.selectEntered.AddListener(OnSwitchFlipped);
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSwitchFlipped);
    }

    private void OnSwitchFlipped(SelectEnterEventArgs args)
    {
        ToggleLights();
    }

    private void ToggleLights()
    {
        isOn = !isOn;
        foreach (var L in lights)
            L.enabled = isOn;
    }
}
