using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard
{
    [SerializeField]
    private static ChessBoard _board;
    public static void InitBoard(int lengthY, int lengthX, UnitMovement movement, ICollection<Cell> cells)
    {
        if (_board == null)
            _board = new(lengthY, lengthX, movement, cells);
    }
    public static ChessBoard Instance { get { return _board; } }

    public int LengthY { get => _grid.GetLength(0); }
    public int LengthX { get => _grid.GetLength(1); }

    private Cell[,] _grid;

    private ChessBoard(int lengthY, int lengthX, UnitMovement movement, ICollection<Cell> cells)
    {
        _grid = new Cell[lengthY, lengthX];
        var cellsQueue = cells.GetEnumerator();
        for (int i = 0; i < lengthY; i++)
        {
            for (int j = 0; j < lengthX; j++)
            {
                if (!cellsQueue.MoveNext())
                {
                    throw new Exception();
                }
                _grid[i, j] = cellsQueue.Current;
            }
        }
    }

    public bool TryToGetCell(Ray ray, out Cell cell)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out cell))
            {
                return true;
            }
        }
        cell = null;
        return false;
    }

    public void MoveUnit(Cell unitCell, Cell cell)
    {
        cell.Occupy(unitCell.OccupiedUnit);
        unitCell.Deoccupy();
    }
}
