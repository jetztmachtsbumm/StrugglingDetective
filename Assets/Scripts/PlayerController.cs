using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private float speed = 5;
    
    private float mouseSensitivity = 45;

    private Camera cam;
    private float camRot = 0;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    private float smoothInputSpeed = .05f;


    private void Awake()
    {
        cam = Camera.main;

        playerInput = new PlayerInput();
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
    }
//comment
    private void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        // Damian Branch Comment
        float x = playerInput.CharacterControls.Movement.ReadValue<Vector2>().x;
        float z = playerInput.CharacterControls.Movement.ReadValue<Vector2>().y;

        Vector3 direction = transform.right * x + transform.forward * z;

        controller.Move(direction * speed * Time.deltaTime);
    }

    private void Turn()
    {
        Vector2 input = playerInput.CharacterControls.Turning.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);

        float mouseX = currentInputVector.x;
        float mouseY = currentInputVector.y;

        camRot -= mouseY;

        camRot = Mathf.Clamp(camRot, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(camRot, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}