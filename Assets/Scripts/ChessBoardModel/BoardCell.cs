public class BoardCell
{
    public int Xpos { get; }
    public int Ypos { get; }
    public Cell _cell { get; }

    public BoardCell(Cell cell, int x, int y)
    {
        _cell = cell;
        Xpos = x;
        Ypos = y;
        if (cell.IsOccupied)
        {
            cell.OccupiedUnit.transform.position = new UnityEngine.Vector3(Xpos, Ypos);
        }
    }
}
