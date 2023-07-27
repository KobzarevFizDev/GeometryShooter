using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HoneycombsFrame
{
    private List<Honeycomb> _honeycombs;

    public static HoneycombsFrame CreateSphericalHoneycombs(int r)
    {
        HoneycombsFrame honeycombsFrame = new HoneycombsFrame();

        Vector3Int center = new Vector3Int(r, r, r);

        for(int x = 0; x < r*2; x++)
            for(int y = 0; y < r*2; y++)
                for(int z = 0; z < r*2; z++)
                {
                    var currentPoint = new Vector3Int(x, y, z);
                    if ((center - currentPoint).sqrMagnitude <= r * r)
                    {
                        honeycombsFrame.AddNewHoneycomb(currentPoint);
                        honeycombsFrame.MakeHoneycombAsEmpty(currentPoint);
                    }
                }


        return honeycombsFrame;
    }

    public static HoneycombsFrame CreateCubicHoneycombs(int a)
    {
        HoneycombsFrame honeycombsFrame = new HoneycombsFrame();

        for (int x = 0; x < a; x++)
            for (int y = 0; y < a; y++)
                for (int z = 0; z < a; z++)
                {
                    var currentPoint = new Vector3Int(x, y, z);
                    honeycombsFrame.AddNewHoneycomb(currentPoint);
                    honeycombsFrame.MakeHoneycombAsEmpty(currentPoint);
                }

        return honeycombsFrame;
    }

    private HoneycombsFrame()
    {
        _honeycombs = new List<Honeycomb>();
    }

    public bool IsExistHoneycomb(Vector3Int coordinates)
    {
        return _honeycombs.Any(h => h.Coordinates == coordinates);
    }

    public bool IsHoneycombEmpty(Vector3Int coordinates)
    {
        Honeycomb honeycomb = GetHoneycombWithPos(coordinates);
        return honeycomb.IsEmpty;
    }

    public void MakeHoneycombAsEmpty(Vector3Int coordinates)
    {
        Honeycomb honeycomb = GetHoneycombWithPos(coordinates);
        honeycomb.IsEmpty = true;
    }

    public void MakeHoneycombAsNotEmpty(Vector3Int coordinates)
    {
        Honeycomb honeycomb = GetHoneycombWithPos(coordinates);
        honeycomb.IsEmpty = false;
    }

    public Vector3Int GetCoordinatesOfFirstEmptyHoneycomb()
    {
        return _honeycombs.First(h => h.IsEmpty).Coordinates;
    }

    private Honeycomb GetHoneycombWithPos(Vector3Int coordinates)
    {
        return _honeycombs.First(h => h.Coordinates == coordinates);
    }

    private void AddNewHoneycomb(Vector3Int coordinates)
    {
        _honeycombs.Add(new Honeycomb(coordinates));
    }
}
