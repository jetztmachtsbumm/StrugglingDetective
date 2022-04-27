using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private float gravityValue = -9.81f;

    private float speed = 2.5f;
    private float height = 40;

    private Vector3 playerVelocity;

    private float mouseSensitivity = 10;

    private Camera cam;
    private float camRot = 0;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    private float smoothInputSpeed = .05f;


    private void Awake()
    {
        cam = Camera.main;

        playerInput = new PlayerInput();
        playerInput.CharacterControls.Jump.performed += a => Jump();
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Turn();
        Debug.Log(controller.isGrounded);

        if (!controller.isGrounded) {
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        if (!controller.isGrounded)
        {
            playerVelocity.y = 0;
        }
    }

    private void Jump() {
        //der char geht nach oben, habe es leider noch nicht geschafft in wieder landen zu lassen.
        //versuchte es über einen rigidbody aber da gab es Probleme.
        Vector3 direction_up = transform.up * height;
        controller.Move(direction_up * speed * Time.deltaTime);
    }

    private void Move()
    {
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