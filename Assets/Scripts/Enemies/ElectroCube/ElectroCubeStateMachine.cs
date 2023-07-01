using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElectroCubeStateMachine : StateMachineBase
{
    private Dictionary<Type, BaseElectroCubeState> _statesMap;

    public void Initialize(ElectroCube electroCube)
    {
        _statesMap = new Dictionary<Type, BaseElectroCubeState>();

        _statesMap[typeof(PatrolStateElectroCube)] = new PatrolStateElectroCube(electroCube, this);
        _statesMap[typeof(ShotStateElectroCube)] = new ShotStateElectroCube(electroCube, this);
    }

    public void SetPatrolState()
    {
        SetState<PatrolStateElectroCube>();
    }

    public void SetShotState()
    {
        SetState<ShotStateElectroCube>();
    }

    private T GetState<T>() where T : BaseElectroCubeState
    {
        return (T)_statesMap[typeof(T)];
    }

    private void SetState<T>() where T : BaseElectroCubeState
    {
        if (null != _currentState)
            _currentState.ExitState();

        T newState = GetState<T>();
        _currentState = newState;
        _currentState.EnterState();
    }
}
