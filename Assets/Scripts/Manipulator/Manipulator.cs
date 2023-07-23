using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    [SerializeField] private ManipulatorPosition _manipulatorPosition;
    [SerializeField] private ClampManipulator _clampManipulator;

    private void Awake()
    {
        OnReachedUnloadingPoint();
    }

    private void OnReachedLoadingPoint()
    {
        _manipulatorPosition.ReachedLoadingPoint -= OnReachedLoadingPoint;
        _manipulatorPosition.ReachedUnloadingPoint += OnReachedUnloadingPoint;
        _manipulatorPosition.MoveToUnoadingPoint();

        _clampManipulator.TakeCargo();

        print("OnReachedLoadingPoint");
    }

    private void OnReachedUnloadingPoint()
    {
        _manipulatorPosition.ReachedLoadingPoint += OnReachedLoadingPoint;
        _manipulatorPosition.ReachedUnloadingPoint -= OnReachedUnloadingPoint;
        _manipulatorPosition.MoveToLoadingPoint();

        _clampManipulator.ReleaseCargo();

        print("OnReachedUnloadingPoint");
    }
}
