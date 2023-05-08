using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerState : BasePlayerState
{
    public RunPlayerState(PlayerMovement playerMovement,
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
        if (!_playerReadInput.IsBoostMove)
            _playerStateMachine.SetWalkState();

        _playerMovement.MoveForward(_playerReadInput.Horizontal, _playerReadInput.Vertical, true);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
