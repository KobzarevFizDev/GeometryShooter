using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    [SerializeField] private ManipulatorPosition _manipulatorPosition;
    [SerializeField] private ClampManipulator _clampManipulator;
    [SerializeField] private ConstructionSite _constructionSite;
    [SerializeField] private ManipulatorWay _manipulatorWay;

    private HoneycombsFrame _honeycombsFrame;
    private Vector3Int _coordinatesOfCellUnderConstructionAtMoment;

    private void Awake()
    {
        Build(HoneycombsFrame.CreateCubicHoneycombs(3));
    }

    public void Build(HoneycombsFrame honeycombsFrame)
    {
        _honeycombsFrame = honeycombsFrame;
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

        UpdateUnloadingPoint();

        print("OnReachedUnloadingPoint");
    }

    private void UpdateUnloadingPoint()
    {
        _honeycombsFrame.MakeHoneycombAsNotEmpty(_coordinatesOfCellUnderConstructionAtMoment);
        _coordinatesOfCellUnderConstructionAtMoment = _honeycombsFrame.GetCoordinatesOfFirstEmptyHoneycomb();
        Vector3 newCoordinatesOfUnloadingPoint = _constructionSite.GetCellPositionInWorldSpace(_coordinatesOfCellUnderConstructionAtMoment);
        _manipulatorWay.SetUnloadingPoint(newCoordinatesOfUnloadingPoint);
        print($"Current unloading point: {_coordinatesOfCellUnderConstructionAtMoment} <-> {newCoordinatesOfUnloadingPoint}");
    }
}
