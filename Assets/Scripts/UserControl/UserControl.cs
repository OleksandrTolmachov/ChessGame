using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    enum PlayerState
    {
        IsChoosing,
        IsMoving
    }
    public int _x;
    public int _y;

    [SerializeField]
    private BoardInit _chessInit;
    private Cell _choosenCell;
    private PlayerState _state;
    private Vector3 camPosition;

    private void Start()
    {
        _chessInit.InitBoard(_x, _y);
        camPosition = new Vector3(_x / 2, 0, -10);
        _state = PlayerState.IsChoosing;
    }

    private void Update()
    {
        Camera.main.transform.position = Vector3.MoveTowards
            (Camera.main.transform.position, camPosition, 1.2f * Time.deltaTime);
        switch (_state)
        {
            case PlayerState.IsChoosing:
                tryToChoose();
                break;
            case PlayerState.IsMoving:
                if(Input.GetMouseButtonDown(0))
                    tryToMove();
                break;
        }
    }

    private void tryToChoose()
    {
        if (ChessBoard.Instance.TryToGetCell(Camera.main.ScreenPointToRay(Input.mousePosition),
            out BoardCell boardCell))
        {
            if(_choosenCell != null && !ReferenceEquals(_choosenCell, boardCell._cell))
            {
                _choosenCell.Deselect();
            }
            boardCell._cell.Select();
            _choosenCell = boardCell._cell;
            if (Input.GetMouseButtonDown(0) && boardCell._cell.IsOccupied)
            {
                camPosition = new Vector3(boardCell.Xpos, boardCell.Ypos, Camera.main.transform.position.z);
                _state = PlayerState.IsMoving;
            }
        }
    }

    private void tryToMove()
    {
        if (ChessBoard.Instance.TryToGetCell(Camera.main.ScreenPointToRay(Input.mousePosition),
            out BoardCell boardCell))
        {
            if(boardCell._cell != null && !boardCell._cell.IsOccupied)
            {
                var command = new MoveToCommand(_choosenCell.OccupiedUnit.transform,
                    new Vector3(boardCell.Xpos, boardCell.Ypos, 0));

                CommandManager.Instance.Execute(command);
                boardCell._cell.Occupy(_choosenCell.OccupiedUnit);
                _choosenCell.Deoccupy();
                _state = PlayerState.IsChoosing;
            }
        }
    }
}
