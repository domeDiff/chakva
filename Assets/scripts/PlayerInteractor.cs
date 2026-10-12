using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactRange = 3f;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            Interact();
        }
    }

    private void Interact()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
