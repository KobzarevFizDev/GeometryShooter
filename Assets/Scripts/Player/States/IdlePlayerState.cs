using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : BasePlayerState
{
    public IdlePlayerState(PlayerMovement playerMovement,
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

        if (_playerReadInput.MoveDirection != Vector3.zero)
            _playerStateMachine.SetWalkState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
