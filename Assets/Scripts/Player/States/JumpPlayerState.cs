using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerState : BasePlayerState
{
    public JumpPlayerState(PlayerMovement playerMovement, 
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
        _playerMovement.Jump();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_playerMovement.IsGround())
            _playerStateMachine.SetIdleState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
