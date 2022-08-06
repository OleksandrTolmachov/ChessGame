using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessDrawer : MonoBehaviour
{
    [SerializeField]
    private Cell _prefabCell;
    [SerializeField]
    private int _x;
    [SerializeField]
    private int _y;
    private void Start()
    {
        DrawBoard();
    }

    private void DrawBoard()
    {
        List<Cell> cells = new();
        for (int i = 0; i < _y; i++)
        {
            for (int j = 0; j < _x; j++)
            {
                var cell = Instantiate(_prefabCell, new Vector2(i, j), Quaternion.identity);
                cell.transform.parent = this.transform;
                cells.Add(cell);

                if((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.green; 
                }
            }
        }
        ChessBoard.InitBoard(_y, _x, cells);
    }
}
