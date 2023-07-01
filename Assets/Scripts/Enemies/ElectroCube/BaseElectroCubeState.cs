public abstract class BaseElectroCubeState : StateBase
{
    protected ElectroCube _electroCube;
    protected ElectroCubeStateMachine _electroCubeStateMachine;
    public BaseElectroCubeState(ElectroCube electroCube, 
        ElectroCubeStateMachine electroCubeStateMachine)
    {
        _electroCube = electroCube;
        _electroCubeStateMachine = electroCubeStateMachine;
    }
}
