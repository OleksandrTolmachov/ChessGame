using System.Collections;
using UnityEngine;

public class MoveToCommand : ICommand
{
    private BoardCell _unitBoardCell;
    private BoardCell _emptyBoardCell;

    public MoveToCommand(BoardCell unitBoardCell, BoardCell emptyBoardCell)
    {
        _unitBoardCell = unitBoardCell;
        _emptyBoardCell = emptyBoardCell;
    }

    public void Execute()
    {
        if (_unitBoardCell.Cell.OccupiedUnit != null)
        {
            ChessBoard.Instance.MoveUnit(_unitBoardCell, _emptyBoardCell);
        }
    }
}
