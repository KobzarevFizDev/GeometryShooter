using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topology
{
    public static class DecardTopology
    {
        public static DecardGrid CreateSphere(int r)
        {
            return null;
        }

        public static DecardGrid CreateCube(int a)
        {
            DecardGrid grid = new DecardGrid(a, a, a);
            for(int x = 0; x < a; x++)
                for(int y = 0; y < a; y++)
                    for(int z = 0; z < a; z++)
                    {
                        grid[x, y, z] = new GridCell(CellState.isTaken);
                    }
            return grid;
        }
    }
}
