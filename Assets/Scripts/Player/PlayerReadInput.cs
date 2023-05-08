using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerReadInput
{
    private PlayerInputActions _playerInputActions;
    private Vector2 _oldMouseInput;

    public float Horizontal { private set; get; }
    public float Vertical { private set; get; }
    public Vector3 MoveDirection { private set; get; }
    public Vector2 MouseInput { private set; get; }
    public bool IsBoostMove { private set; get; }


    public Action JumpEvent;
    public Action BoostEvent;
    public PlayerReadInput()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Jump.started += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => JumpEvent?.Invoke();
        _playerInputActions.Player.Boost.started += ActiveBoostMode;
        _playerInputActions.Player.Boost.canceled += DeactiveBoostMode;
        _playerInputActions.Enable();
    }

    public void ReadInputs()
    {
        ReadMoveInput();
        ReadMouseInput();
    }

    private void ReadMoveInput()
    {
        Horizontal = _playerInputActions.Player.Move.ReadValue<Vector2>().x;
        Vertical = _playerInputActions.Player.Move.ReadValue<Vector2>().y;
        MoveDirection = new Vector3(Horizontal, 0, Vertical);
    }

    private void ReadMouseInput()
    {
        Vector2 input = _playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        MouseInput = input - _oldMouseInput;
        _oldMouseInput = input;
    }

    private void ActiveBoostMode(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsBoostMove = true;
        BoostEvent?.Invoke();
    }

    private void DeactiveBoostMode(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsBoostMove = false;
    }
}