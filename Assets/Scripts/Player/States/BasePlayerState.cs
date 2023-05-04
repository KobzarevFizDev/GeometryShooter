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
        RotateAround();
    }
    public virtual void ExitState() { }

    private void ReadPlayerInputs()
    {
        ReadMouseInput();
        ReadMoveInput();
    }

    private void ReadMoveInput()
    {
        MoveDirection = new Vector3(_playerInputActions.Player.Move.ReadValue<Vector2>().x, 0, _playerInputActions.Player.Move.ReadValue<Vector2>().y);
    }

    private void ReadMouseInput()
    {
        Vector2 input = _playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        MouseInput = input - _oldMouseInput;
        _oldMouseInput = input;
    }

    private void RotateAround()
    {

    }
}
