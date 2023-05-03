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
        Debug.Log("Enter to idle state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Update to idle state");

        if (MoveInput != Vector2.zero)
            _playerStateMachine.SetWalkState();
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit from exit state");
    }
}
