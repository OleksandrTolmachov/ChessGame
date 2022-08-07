using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    public UnityEvent OnSelected;
    public UnityEvent OnDeselected;

    public bool IsOccupied { get => OccupiedUnit != null; }

    public Unit OccupiedUnit;

    public void Occupy(Unit unit)
    {
        if (OccupiedUnit != null)
        {
            OccupiedUnit = unit;
        }
    }

    public void Deoccupy()
    {
        OccupiedUnit = null;
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
