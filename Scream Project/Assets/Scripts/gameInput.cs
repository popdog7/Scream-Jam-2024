using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class gameInput : MonoBehaviour
{
    public PlayerInput player_input_actions;
    public event EventHandler on_jump_action;
    public event EventHandler on_interact_action;

    private void Awake()
    {
        player_input_actions = new PlayerInput();
        player_input_actions.Player.Enable();

        player_input_actions.Player.Jump.performed += jump_performed;
        player_input_actions.Player.Interact.performed += interact_performed;
    }

    private void interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        on_interact_action?.Invoke(this, EventArgs.Empty);
    }

    private void jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        on_jump_action?.Invoke(this, EventArgs.Empty);
    }


    public Vector2 getMovementVector()
    {
        Vector2 inputVector = player_input_actions.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    public Vector2 getCameraVector()
    {
        Vector2 inputVector = player_input_actions.Player.Look.ReadValue<Vector2>();

        return inputVector;
    }
}

