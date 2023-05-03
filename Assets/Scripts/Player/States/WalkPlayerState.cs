using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlayerState : BasePlayerState
{
    public WalkPlayerState(PlayerMovement playerMovement, 
                              PlayerInputActions playerInputActions,
                              CharacterController characterController) : base(playerMovement, 
                                                                              playerInputActions,
                                                                              characterController)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter to walk state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Update to walk state");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit from walk state");
    }
}
