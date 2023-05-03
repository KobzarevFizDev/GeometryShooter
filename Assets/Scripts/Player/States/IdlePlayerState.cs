using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : BasePlayerState
{
    public IdlePlayerState(PlayerMovement playerMovement, 
                              PlayerInputActions playerInputActions,
                              CharacterController characterController) : base(playerMovement, 
                                                                              playerInputActions,
                                                                              characterController)
    {
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
        //Debug.Log($"Move: {MoveInput}. Mouse: {MouseInput}");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit from exit state");
    }
}
