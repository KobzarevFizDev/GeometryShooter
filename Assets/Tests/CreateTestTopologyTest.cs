using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Topology;

public class CreateTestTopologyTest
{
    [Test]
    public void CreateCubeTopology()
    {
        DecardGrid cube = DecardTopology.CreateCube(3);
        int xSize = cube.XSize;
        int ySize = cube.YSize;
        int zSize = cube.ZSize;
        for(int x = 0; x < xSize; x++)
            for(int y = 0; y < ySize; y++)
                for(int z = 0; z < zSize; z++)
                {
                    Assert.IsTrue(cube[x, y, z].CellState == CellState.isTaken);
                }
    }
}
