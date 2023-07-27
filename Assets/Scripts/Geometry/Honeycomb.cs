using UnityEngine;

public class Honeycomb
{
    private float _size = 2.4f;
    public bool IsEmpty { get; set; }

    // TODO: Coordinates and pos очень похожие имена
    public Vector3Int Coordinates { private set; get; }
    public Vector3 Pos => new Vector3(Coordinates.x, Coordinates.y, Coordinates.z) * _size;
    public Honeycomb(Vector3Int coordinates)
    {
        Coordinates = coordinates;
        IsEmpty = true;
    }
}
