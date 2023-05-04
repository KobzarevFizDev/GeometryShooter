using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : BasePlayerState
{
    private PlayerStateMachine _playerStateMachine;
    public IdlePlayerState(PlayerMovement playerMovement, 
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

        if (MoveDirection != Vector3.zero)
            _playerStateMachine.SetWalkState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
