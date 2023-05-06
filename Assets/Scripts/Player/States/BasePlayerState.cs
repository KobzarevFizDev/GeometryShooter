using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState
{
    protected PlayerMovement _playerMovement;
    protected PlayerInputActions _playerInputActions;
    protected CharacterController _characterController;

    protected Vector3 MoveDirection { private set; get; }
    protected Vector2 MouseInput { private set; get; }
    protected float Horizontal { private set; get; }
    protected float Vertical { private set; get; }

    private Vector2 _oldMouseInput;

    public BasePlayerState(PlayerMovement playerMovement, 
                              PlayerInputActions playerInputActions,
                              CharacterController characterController)
    {
        _playerMovement = playerMovement;
        _playerInputActions = playerInputActions;
        _characterController = characterController;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() 
    {
        ReadPlayerInputs();
    }
    public virtual void ExitState() { }

    private void ReadPlayerInputs()
    {
        ReadMouseInput();
        ReadMoveInput();
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
}
