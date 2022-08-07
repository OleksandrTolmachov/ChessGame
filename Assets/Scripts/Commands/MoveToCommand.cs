using System.Collections;
using UnityEngine;

public class MoveToCommand : ICommand
{
    private Cell _unitCell;
    private Cell _emptyCell;

    public MoveToCommand(Cell unitCell, Cell emptyCell)
    {
        _unitCell = unitCell;
        _emptyCell = emptyCell;
    }

    public void Execute()
    {
        if (_unitCell.OccupiedUnit != null)
        {
            ChessBoard.Instance.MoveUnit(_unitCell, _emptyCell);
        }
    }
}
