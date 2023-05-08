using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState
{
    protected PlayerMovement _playerMovement;
    protected CharacterController _characterController;
    protected PlayerReadInput _playerReadInput;
    protected PlayerStateMachine _playerStateMachine;

    public BasePlayerState(PlayerMovement playerMovement,
                           CharacterController characterController,
                           PlayerReadInput playerReadInput,
                           PlayerStateMachine playerStateMachine)
    {
        _playerMovement = playerMovement;
        _characterController = characterController;
        _playerReadInput = playerReadInput;
        _playerStateMachine = playerStateMachine;
    }

    public virtual void EnterState() 
    {
        _playerReadInput.JumpEvent += CheckPossibilityOfMakingJump;
    }
    public virtual void UpdateState() 
    {
        _playerReadInput.ReadInputs();


    }
    public virtual void ExitState() 
    {
        _playerReadInput.JumpEvent -= CheckPossibilityOfMakingJump;
    }

    private void CheckPossibilityOfMakingJump()
    {
        if (_playerMovement.IsGround())
        {
            _playerStateMachine.SetJumpState();
        }
    }

}
