using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; 

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor))]
public class ChangeTextOnSocketSelect : MonoBehaviour
{
    public TextMeshProUGUI targetText;

    [TextArea] public string newText = "Object inserted";

    UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        socket.selectEntered.AddListener(OnSocketSelect);
    }

    void OnDestroy()
    {
        socket.selectEntered.RemoveListener(OnSocketSelect);
    }

    private void OnSocketSelect(SelectEnterEventArgs args)
    {
        if (targetText != null)
            targetText.text = newText;
    }
}
