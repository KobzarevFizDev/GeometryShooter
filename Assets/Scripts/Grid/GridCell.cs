using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public int X { private set; get; }
    public int Y { private set; get; }
    public int Z { private set; get; }
    public void Initialize(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
