using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] Joystick joystick;
    //private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerInput = GetComponent<PlayerInput>();
    }

    public void Walk()
    {
        Vector2 moveInput = joystick.Direction;
        rb.velocity = moveInput * moveSpeed;
        Debug.Log(joystick.Direction);
    }

    private void OnEnable()
    {
        //playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
