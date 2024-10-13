using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    public PlayerInputActions playerControll;
    private InputAction CameraMovementInput;
    private Vector2 _lookDirection = Vector2.zero;
    private float mouseX;
    private float mouseY;


    public float mouseSensitivity = 100f;

    public Transform playerBody;
    
    float xRotation = 0f;


    private void Awake()
    {
        playerControll = new PlayerInputActions();
    }

    private void OnEnable()
    {
        CameraMovementInput = playerControll.Player.Look;
        CameraMovementInput.Enable();
        
    }

    private void OnDisable()
    {
        CameraMovementInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           
    }

    // Update is called once per frame
    void Update()
    {
        _lookDirection = CameraMovementInput.ReadValue<Vector2>();
        mouseX = _lookDirection.x * mouseSensitivity * Time.deltaTime;
        mouseY = _lookDirection.y * mouseSensitivity * Time.deltaTime;

        xRotation -= (mouseY);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
