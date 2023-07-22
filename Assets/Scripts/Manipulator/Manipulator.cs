using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManipulatorPosition))]
public class Manipulator : MonoBehaviour
{
    private ManipulatorPosition _manipulatorPosition;

    private bool _movementSwitch = false;
    private void Awake()
    {
        _manipulatorPosition = GetComponent<ManipulatorPosition>();

        OnReachedUnloadingPoint();
    }

    private void OnReachedLoadingPoint()
    {
        _manipulatorPosition.ReachedLoadingPoint -= OnReachedLoadingPoint;
        _manipulatorPosition.ReachedUnloadingPoint += OnReachedUnloadingPoint;
        _manipulatorPosition.MoveToUnoadingPoint();
        print("OnReachedLoadingPoint");
    }

    private void OnReachedUnloadingPoint()
    {
        _manipulatorPosition.ReachedLoadingPoint += OnReachedLoadingPoint;
        _manipulatorPosition.ReachedUnloadingPoint -= OnReachedUnloadingPoint;
        _manipulatorPosition.MoveToLoadingPoint();
        print("OnReachedUnloadingPoint");
    }
}
