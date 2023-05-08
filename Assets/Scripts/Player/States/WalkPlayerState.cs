using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlayerState : BasePlayerState
{
    public WalkPlayerState(PlayerMovement playerMovement,
                           CharacterController characterController,
                           PlayerStateMachine playerStateMachine,
                           PlayerReadInput playerReadInput) : base(playerMovement,
                                                                   characterController,
                                                                   playerReadInput,
                                                                   playerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(_playerReadInput.MoveDirection == Vector3.zero)
            _playerStateMachine.SetIdleState();


        if (_playerMovement.IsGrounded())
            _playerMovement.MoveForward(_playerReadInput.Horizontal, _playerReadInput.Vertical);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
