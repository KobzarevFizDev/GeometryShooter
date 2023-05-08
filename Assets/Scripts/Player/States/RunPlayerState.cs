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
