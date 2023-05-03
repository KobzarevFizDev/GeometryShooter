using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine
{
    private BasePlayerState _currentState;
    private Dictionary<Type, BasePlayerState> _statesMap;
    public void Initialize(PlayerMovement playerMovement, 
                           CharacterController characterController,
                           PlayerInputActions playerInputActions)
    {
        _statesMap = new Dictionary<Type, BasePlayerState>();

        _statesMap[typeof(IdlePlayerState)] = new IdlePlayerState(playerMovement, playerInputActions, characterController, this);
        _statesMap[typeof(WalkPlayerState)] = new WalkPlayerState(playerMovement, playerInputActions, characterController, this);
        _statesMap[typeof(RunPlayerState)] = new RunPlayerState(playerMovement, playerInputActions, characterController, this);
    }

    public void Update()
    {
        if (null != _currentState)
            _currentState.UpdateState();
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
