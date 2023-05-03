using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerState : BasePlayerState
{
    private PlayerStateMachine _playerStateMachine;
    public RunPlayerState(PlayerMovement playerMovement, 
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
        Debug.Log("Enter to run state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Update to run state");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit from run state");
    }
}
