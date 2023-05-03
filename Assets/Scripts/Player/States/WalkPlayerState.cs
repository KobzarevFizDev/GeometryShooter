using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlayerState : BasePlayerState
{
    private PlayerStateMachine _playerStateMachine;
    public WalkPlayerState(PlayerMovement playerMovement, 
                              PlayerInputActions playerInputActions,
                              CharacterController characterController,
                              PlayerStateMachine playerStateMachine) : base(playerMovement, 
                                                                              playerInputActions,
                                                                              characterController)
    {
        _playerStateMachine = playerStateMachine;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter to walk state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Update to walk state");

        if(MoveInput == Vector2.zero)
            _playerStateMachine.SetIdleState();


        if (_playerMovement.IsGrounded())
            _playerMovement.MoveToDirection(MoveInput);
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit from walk state");
    }
}
