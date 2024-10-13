using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("input")]
    public PlayerInputActions playerControll;
    private InputAction Movement;
    private Vector2 _moveInput;
    private float moveX;
    private float moveZ;
    public CharacterController controller;

    [Header("Falling")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    [Header("move speeds")]
    public float speed = 12f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    

    private void Awake()
    {
        playerControll = new PlayerInputActions();
    }

    private void OnEnable()
    {
        Movement = playerControll.Player.Move;
        Movement.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        _moveInput = Movement.ReadValue<Vector2>();
        moveX = _moveInput.x;
        moveZ = _moveInput.y;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        

    }
}
