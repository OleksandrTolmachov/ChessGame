using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard
{
    [SerializeField]
    private static ChessBoard _board; 
    public static void InitBoard(int lengthY, int lengthX, ICollection<Cell> cells)
    {
        if (_board == null)
            _board = new(lengthY, lengthX, cells);
    }
    public static ChessBoard Instance { get { return _board; } }

    public int LengthY { get => _grid.GetLength(0); }
    public int LengthX { get => _grid.GetLength(1); }

    private BoardCell[,] _grid;

    private ChessBoard(int lengthY, int lengthX, ICollection<Cell> cells)
    {
        _grid = new BoardCell[lengthY, lengthX];
        var cellsQueue = cells.GetEnumerator();
        for (int i = 0; i < lengthY; i++)
        {
            for (int j = 0; j < lengthX; j++)
            {
                if (!cellsQueue.MoveNext())
                {
                    throw new Exception();
                }
                _grid[i, j] = new BoardCell(cellsQueue.Current, i, j);
            }
        }
    }

    public bool TryToGetCell(Ray ray, out BoardCell bcell)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent<Cell>(out Cell cell))
            {
                bcell = findMatchCell(cell);
                return true;
            }
        }
        bcell = null;
        return false;
    }

    private BoardCell findMatchCell(Cell cell)
    {
        foreach (var item in _grid)
        {
            if(ReferenceEquals(item._cell, cell))
            {
                return item;
            }
        }
        return null;
    }
}
