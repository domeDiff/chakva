using System.Threading;
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 2f;

    private bool isOpen;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = transform.rotation;

        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    public void Interact()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, openSpeed * Time.deltaTime);
    }
}
