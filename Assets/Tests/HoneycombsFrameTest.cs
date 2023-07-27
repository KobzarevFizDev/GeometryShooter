using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HoneycombsFrameTest
{
    [Test]
    public void CreateCubicHoneycombsFrame()
    {
        int a = 4;
        HoneycombsFrame cubicHoneycombs = HoneycombsFrame.CreateCubicHoneycombs(a);
        for(int x = 0; x < a; x++)
            for(int y = 0; y < a; y++)
                for(int z = 0; z < a; z++)
                {
                    Vector3Int currentPoint = new Vector3Int(x, y, z);
                    Assert.IsTrue(cubicHoneycombs.IsExistHoneycomb(currentPoint), $"Honeycomb x={x} y={y} z={z} is not exist");
                    Assert.IsTrue(cubicHoneycombs.IsHoneycombEmpty(currentPoint), $"Honeycomb x={x} y={y} z={z} is not empty");
                }
    }

    [Test]
    public void CreateSphericalHoneycombsFrame()
    {
        int r = 3;

        HoneycombsFrame honeycombsFrame = HoneycombsFrame.CreateSphericalHoneycombs(r);
        Vector3Int center = new Vector3Int(r, r, r);

        for (int x = 0; x < r * 2; x++)
            for (int y = 0; y < r * 2; y++)
                for (int z = 0; z < r * 2; z++)
                {
                    var currentPoint = new Vector3Int(x, y, z);
                    if ((center - currentPoint).sqrMagnitude <= r * r)
                    {
                        Assert.IsTrue(honeycombsFrame.IsHoneycombEmpty(currentPoint));
                    }
                }
    }
}
