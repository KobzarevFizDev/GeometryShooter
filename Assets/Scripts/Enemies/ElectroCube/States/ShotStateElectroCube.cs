using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStateElectroCube : BaseElectroCubeState
{
    public ShotStateElectroCube(ElectroCube electroCube, 
                                ElectroCubeStateMachine electroCubeStateMachine) : 
                                base(electroCube, electroCubeStateMachine) { }
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if (!_electroCube.IsPlayerCloseEnoughToAttack)
        {
            _electroCubeStateMachine.SetPatrolState();
        }
    }
}
