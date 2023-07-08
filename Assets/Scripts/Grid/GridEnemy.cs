using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEnemy
{
    private List<GridCell> _cells = new List<GridCell>();

    public GridEnemy(int a)
    {
        _cells = new List<GridCell>();

        for(int x = 0; x < a; x++)
            for(int y = 0; y < a; y++)
                for(int z = 0; z < a; z++)
                {
                    _cells
                }
    }
}
