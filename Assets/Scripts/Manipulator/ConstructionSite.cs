using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionSite : MonoBehaviour
{
    [SerializeField] private Transform _referencePoint;
    [SerializeField] private GameObject _cellPrefab;

    private const int XSize = 10;
    private const int YSize = 5;
    private const int ZSize = 5;
    private const float CellSize = 2;

    private void Start()
    {
        for(int x = 0; x < XSize; x++)
            for(int y = 0; y < YSize; y++)
                for(int z = 0; z < ZSize; z++)
                {
                    var cell = Instantiate(_cellPrefab, transform);
                    cell.transform.position = GetCellPositionInLocalSpace(new Vector3Int(x,y,z));
                    cell.transform.rotation = Quaternion.identity;
                }
    }

    public Vector3 GetCellPositionInWorldSpace(Vector3Int coordinates)
    {
        Vector3 localPosition = GetCellPositionInLocalSpace(coordinates);
        Vector3 worldPosition = _referencePoint.TransformPoint(localPosition);
        return worldPosition;
    }

    private Vector3 GetCellPositionInLocalSpace(Vector3Int coordinates)
    {
        Vector3 localPosition = (Vector3)coordinates * CellSize + _referencePoint.transform.position + Vector3.one * CellSize / 2f;
        return localPosition;
    }
}
