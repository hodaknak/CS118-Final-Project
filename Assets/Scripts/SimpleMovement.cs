using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPivot;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float mouseSensitivity = 0.1f;
    [SerializeField]
    private float maxLookAngle = 90f;

    private CharacterController controller;

    private Vector2 lookInput;
    private float pitch = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    public void OnLook(InputValue value)
    {
        Vector2 lookInput = value.Get<Vector2>();
        
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        // Horizontal rotation (player body)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (camera)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
