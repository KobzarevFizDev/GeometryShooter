using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineBase
{
    protected StateBase _currentState;

    public void Update()
    {
        if (null != _currentState)
            _currentState.UpdateState();
    }
}
