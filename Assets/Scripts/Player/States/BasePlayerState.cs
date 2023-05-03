using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState
{
    protected PlayerMovement _playerMovement;
    protected PlayerInputActions _playerInputActions;
    protected CharacterController _characterController;

    protected Vector2 MoveInput { private set; get; }
    protected Vector2 MouseInput { private set; get; }

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
        MoveInput = _playerInputActions.Player.Move.ReadValue<Vector2>();
        MouseInput = _playerInputActions.Player.MousePosition.ReadValue<Vector2>();
    }
    public virtual void ExitState() { }

    private void RotateAround()
    {

    }

}
