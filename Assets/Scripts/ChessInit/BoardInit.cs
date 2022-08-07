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
    private Unit _unit;
    #endregion

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
        var unit = Instantiate(_unit, new Vector2(0, 0), Quaternion.identity);
        cells[0].Occupy(unit);
        ChessBoard.InitBoard(y, x, cells);
    }
}
