using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private TMP_Text interactionPrompt;


    private InteractableObject currentInteractable;
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
        CheckForInteractable();

        if (currentInteractable!= null && inputActions.Player.Interact.WasPressedThisFrame())
        {
            currentInteractable.Interact();
        }
    }

    private void CheckForInteractable()
    {
        currentInteractable = null;

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            currentInteractable = hit.collider.GetComponent<InteractableObject>();

            interactionPrompt.gameObject.SetActive(currentInteractable != null);
        }
    }
}
