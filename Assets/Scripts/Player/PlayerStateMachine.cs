using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : StateMachineBase
{
    private Dictionary<Type, BasePlayerState> _statesMap;
    public void Initialize(PlayerMovement playerMovement, 
                           CharacterController characterController,
                           PlayerReadInput playerReadInput)
    {
        _statesMap = new Dictionary<Type, BasePlayerState>();

        _statesMap[typeof(IdlePlayerState)] = new IdlePlayerState(playerMovement, characterController, this, playerReadInput);
        _statesMap[typeof(WalkPlayerState)] = new WalkPlayerState(playerMovement, characterController, this, playerReadInput);
        _statesMap[typeof(RunPlayerState)] = new RunPlayerState(playerMovement, characterController, this, playerReadInput);
        _statesMap[typeof(JumpPlayerState)] = new JumpPlayerState(playerMovement, characterController, this, playerReadInput);
    }

    public void SetIdleState()
    {
        SetState<IdlePlayerState>();
    }

    public void SetWalkState()
    {
        SetState<WalkPlayerState>();
    }

    public void SetRunState()
    {
        SetState<RunPlayerState>();
    }

    public void SetJumpState()
    {
        SetState<JumpPlayerState>();
    }

    private T GetState<T>() where T : BasePlayerState
    {
        return (T) _statesMap[typeof(T)];
    }

    private void SetState<T>() where T : BasePlayerState
    {
        if (null != _currentState)
            _currentState.ExitState();

        T newState = GetState<T>();
        _currentState = newState;
        _currentState.EnterState();
    }
}
