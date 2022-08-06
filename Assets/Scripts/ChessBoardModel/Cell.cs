using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsOccupied { get => _occupiedUnit != null; }
    private Unit _occupiedUnit;

    public void Occupy(Unit unit)
    {
        if (_occupiedUnit != null)
        {
            _occupiedUnit = unit;
        }
    }

    public void Deselect()
    {
        _occupiedUnit = null;
    }
}
