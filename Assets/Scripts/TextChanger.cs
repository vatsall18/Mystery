using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;  

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable))]
public class ChangeTextOnSelect : MonoBehaviour
{
    [Header("Text to update")]
    public TextMeshProUGUI targetText;  

    [TextArea] public string newText = "Hello, world";

    UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable simpleInt;

    void Awake()
    {
        simpleInt = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        simpleInt.selectEntered.AddListener(OnSelected);
    }

    void OnDestroy()
    {
        simpleInt.selectEntered.RemoveListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        if (targetText != null)
            targetText.text = newText;
    }
}
