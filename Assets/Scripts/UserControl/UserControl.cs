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
    private BoardInit _chessDrawer;
    private Cell _choosenCell;
    private PlayerState _state;

    private void Start()
    {
        _chessDrawer.InitBoard(_y, _x);
        Camera.main.transform.position = new Vector3(_x / 2, 0, -10);
        _state = PlayerState.IsChoosing;
    }

    private void Update()
    {
        switch (_state)
        {
            case PlayerState.IsChoosing:
                tryToChoose();
                break;
            case PlayerState.IsMoving:
                tryToMove();
                break;
        }
    }

    private void tryToChoose()
    {
        if (ChessBoard.Instance.TryToGetCell(Camera.main.ScreenPointToRay(Input.mousePosition), out BoardCell boardCell))
        {
            if(_choosenCell != null && !ReferenceEquals(_choosenCell, boardCell._cell))
            {
                _choosenCell.Deselect();
            }
            boardCell._cell.Select();
            _choosenCell = boardCell._cell;

            CommandManager.Instance.Execute(new CameraMoveToCommand(
               new Vector3(boardCell.Xpos, boardCell.Ypos, Camera.main.transform.position.z)));
            if (Input.GetMouseButtonDown(0) && boardCell._cell.IsOccupied)
            {
                _state = PlayerState.IsMoving;
            }
        }
    }

    private void tryToMove()
    {

    }
}
