using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private Light flashlight;

    [Header("Crouch")]
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float crouchingHeight = 1.2f;
    [SerializeField] private float standingCameraHeight = 0.8f;
    [SerializeField] private float crouchingCameraHeight = 0.45f;
    [SerializeField] private float crouchSpeed = 8f;
    private bool isCrouching;

    private float verticalVelocity;
    private CharacterController controller;
    private PlayerInputActions inputActions;
    private float cameraRotationX;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Update()
    {
        Move();
        Look();
        FlashLightToggle();
        Crouch();
        CrouchCamera();
    }

    private void Move()
    {
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 movement = transform.right * input.x + transform.forward * input.y;

        if (controller.isGrounded)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        movement.y = verticalVelocity;

        controller.Move(moveSpeed * Time.deltaTime * movement);
    }

    private void Look()
    {
        Vector2 mouse = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = mouse.x * lookSpeed * Time.deltaTime;
        float mouseY = mouse.y * lookSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -80f, 80f);

        playerCamera.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
    }

    private void FlashLightToggle()
    {
        if (inputActions.Player.Flashlight.WasPressedThisFrame())
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }

    private void Crouch()
    {
        if (inputActions.Player.Crouch.IsPressed())
        {
            isCrouching = true;
            controller.height = crouchingHeight;
        }

        else
        {
            isCrouching = false;
            controller.height = standingHeight;
        }
    }

    private void CrouchCamera()
    {
        float targetHeight;

        if (isCrouching)
            targetHeight = crouchingCameraHeight;

        else
            targetHeight = standingCameraHeight;

        Vector3 cameraPosition = playerCamera.localPosition;

        cameraPosition.y = Mathf.Lerp(cameraPosition.y, targetHeight, crouchSpeed * Time.deltaTime);

        playerCamera.localPosition = cameraPosition;
    }
}
