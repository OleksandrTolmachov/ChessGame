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

    private Cell _choosenCell;
    private PlayerState _state;
    private Vector3 camPosition;
    [SerializeField]
    private float shiftSpeed;

    private void Start()
    {
        camPosition = new Vector3(0, 0, -10);
        _state = PlayerState.IsChoosing;
    }

    private void Update()
    {
        Camera.main.transform.position = Vector3.Lerp
            (Camera.main.transform.position, camPosition, shiftSpeed * Time.deltaTime);
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
            out Cell cell))
        {
            if(_choosenCell != null && !ReferenceEquals(_choosenCell, cell))
            {
                _choosenCell.Deselect();
            }
            cell.Select();
            _choosenCell = cell;
            if (Input.GetMouseButtonDown(0) && _choosenCell.IsOccupied)
            {
                camPosition = new Vector3
                    (cell.transform.position.x, cell.transform.position.y, Camera.main.transform.position.z);
                _state = PlayerState.IsMoving;
            }
        }
    }

    private void tryToMove()
    {
        if (ChessBoard.Instance.TryToGetCell(Camera.main.ScreenPointToRay(Input.mousePosition),
            out Cell cell))
        {
            if(cell != null && !cell.IsOccupied)
            {
                var command = new MoveToCommand(_choosenCell, cell);

                CommandManager.Instance.Execute(command);
                _state = PlayerState.IsChoosing;
            }
            else if (cell != null && cell.IsOccupied)
            {
                _state = PlayerState.IsChoosing;
            }
        }
    }
}
