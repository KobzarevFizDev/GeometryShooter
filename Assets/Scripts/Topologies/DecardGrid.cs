using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topology
{
    public class DecardGrid
    {
        public int XSize;
        public int YSize;
        public int ZSize;

        private GridCell[,,] _grid;
        public DecardGrid(int xSize, int ySize, int zSize)
        {
            _grid = new GridCell[xSize,ySize,zSize];

            XSize = xSize;
            YSize = ySize;
            ZSize = zSize;
        }

        public GridCell this[int x, int y, int z]
        {
            get { return _grid[x, y, z]; }
            set { _grid[x, y, z] = value; }
        }
    }
}
