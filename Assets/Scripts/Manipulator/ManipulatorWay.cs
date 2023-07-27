using UnityEngine;

public class ManipulatorWay : MonoBehaviour
{
    [SerializeField] private Transform _loadingPoint;
    [SerializeField] private Transform _unloadingPoint;
    public void SetLoadingPoint(Vector3 coordinate)
    {
        _loadingPoint.transform.position = coordinate;
    }

    public void SetUnloadingPoint(Vector3 coordinate)
    {
        _unloadingPoint.transform.position = coordinate;
    }
}
