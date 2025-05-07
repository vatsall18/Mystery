using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorOpener : MonoBehaviour
{
    public Transform door;

    public Vector3 openLocalPosition = new Vector3(-0.19f, 0.1984f, -0.353f);
    public Vector3 openLocalEulerAngles = new Vector3(0f, 90f, 0f);

    public void OpenDoor(SelectEnterEventArgs args)
    {
        door.localPosition = openLocalPosition;
        door.localEulerAngles = openLocalEulerAngles;
    }
}
