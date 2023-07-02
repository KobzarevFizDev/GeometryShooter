using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topology
{
    public enum CellState { isFree, isTaken, isEmpty }
    public class GridCell
    {
        public CellState CellState { private set; get; }

        public GridCell(CellState cellState)
        {
            CellState = cellState;
        }
    }
}
