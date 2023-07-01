using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStateElectroCube : BaseElectroCubeState
{
    private Transform _currentPatrolPoint;
    public PatrolStateElectroCube(ElectroCube electroCube, 
        ElectroCubeStateMachine electroCubeStateMachine) : 
        base(electroCube, electroCubeStateMachine) { }
    
    public override void EnterState()
    {
         _currentPatrolPoint = _electroCube.FindAvailablePatrolPoint();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        Vector3 dir = _currentPatrolPoint.transform.position - _electroCube.transform.position;
        dir.y = 0;
        dir = dir.normalized;
        _electroCube.transform.Translate(dir * Time.deltaTime);

        if (_electroCube.IsPlayerCloseEnoughToAttack)
        {
            _electroCubeStateMachine.SetShotState();
        }
    }
}
