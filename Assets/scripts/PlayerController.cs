using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private Transform playerCamera;

    private CharacterController controller;
    private float cameraRotationX;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector2 input = Keyboard.current != null ? Keyboard.current.wasd.ReadValue() : Vector2.zero;

        Vector3 movement = transform.right * input.x + transform.forward * input.y;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {

    }
}
