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
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(MoveDirection == Vector3.zero)
            _playerStateMachine.SetIdleState();


        if (_playerMovement.IsGrounded())
            _playerMovement.MoveForward(MoveDirection);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
