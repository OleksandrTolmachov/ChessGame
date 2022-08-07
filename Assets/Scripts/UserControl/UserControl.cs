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

    private BoardCell _choosenCell;
    private PlayerState _state;
    private Vector3 camPosition;

    private void Start()
    {
        camPosition = new Vector3(0, 0, -10);
        _state = PlayerState.IsChoosing;
    }

    private void Update()
    {
        Camera.main.transform.position = Vector3.MoveTowards
            (Camera.main.transform.position, camPosition, 2.2f * Time.deltaTime);
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
            if(_choosenCell != null && !ReferenceEquals(_choosenCell, boardCell.Cell))
            {
                _choosenCell.Cell.Deselect();
            }
            boardCell.Cell.Select();
            _choosenCell = boardCell;
            if (Input.GetMouseButtonDown(0) && boardCell.Cell.IsOccupied)
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
            if(boardCell.Cell != null && !boardCell.Cell.IsOccupied)
            {
                var command = new MoveToCommand(_choosenCell, boardCell);

                CommandManager.Instance.Execute(command);
                _state = PlayerState.IsChoosing;
            }
        }
    }
}
