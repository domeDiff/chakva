
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 2f;

    private Transform pivot;
    private Vector3 closedPosition;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen;

    private void Start()
    {
        // Create a pivot at the door's left edge.
        pivot = new GameObject("DoorPivot").transform;

        pivot.position = door.position
                         - door.right * 0.5f;

        pivot.rotation = door.rotation;

        // Preserve the door's current world position.
        door.SetParent(pivot, true);

        closedPosition = pivot.position;
        closedRotation = pivot.rotation;

        openRotation = closedRotation *
                       Quaternion.Euler(0f, openAngle, 0f);
    }

    public void Interact()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        Quaternion targetRotation =
            isOpen ? openRotation : closedRotation;

        pivot.rotation = Quaternion.Slerp(
            pivot.rotation,
            targetRotation,
            openSpeed * Time.deltaTime
        );
    }
}
