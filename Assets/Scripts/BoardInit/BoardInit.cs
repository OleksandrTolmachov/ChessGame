using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInit : MonoBehaviour
{
    #region fields
    [SerializeField]
    private Cell _prefabCell1;
    [SerializeField]
    private Cell _prefabCell2;
    [SerializeField]
    private Unit _unit1, _unit2;
    [SerializeField]
    private UnitMovement _movement;
    [SerializeField]
    private int _xb;
    [SerializeField]
    private int _yb;

    #endregion

    private void Start()
    {
        InitBoard(_xb, _yb);
    }

    public void InitBoard(int y, int x)
    {
        if(ChessBoard.Instance != null)
        {
            return;
        }
        List<Cell> cells = new();
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                var cell = Instantiate(_prefabCell1, new Vector2(i, j), Quaternion.identity);
                cell.transform.parent = this.transform;
                cells.Add(cell);

                if((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.green; 
                }
            }
        }
        var unit = Instantiate(_unit1, new Vector2(0, 0), Quaternion.identity);
        cells[0].Occupy(unit);
        var unit2 = Instantiate(_unit2, new Vector2(0, 0), Quaternion.identity);
        cells[3].Occupy(unit2);
        ChessBoard.InitBoard(_yb, _xb, _movement, cells);
    }
}
