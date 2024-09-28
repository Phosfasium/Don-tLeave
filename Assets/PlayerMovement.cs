using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputActions playerControll;
    private InputAction Movement;
    private Vector2 _moveInput;
    private float moveX;
    private float moveZ;

    public CharacterController controller;

    public float speed = 12f;
    

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
        _moveInput = Movement.ReadValue<Vector2>();
        moveX = _moveInput.x;
        moveZ = _moveInput.y;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);
    }
}
