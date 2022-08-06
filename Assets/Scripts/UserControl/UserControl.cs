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

    private Unit _choosenUnit;
    private PlayerState _state;

    private void Start()
    {
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

    }

    private void tryToMove()
    {

    }
}
