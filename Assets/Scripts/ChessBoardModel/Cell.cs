using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    public UnityEvent OnSelected;
    public UnityEvent OnDeselected;
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
        OnDeselected?.Invoke();
    }

    public void Select()
    {
        OnSelected?.Invoke();
    }
}
