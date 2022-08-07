public class BoardCell
{
    public int Xpos { get; }
    public int Ypos { get; }
    public Cell _cell { get; }

    public BoardCell(Cell cell, int y, int x)
    {
        _cell = cell;
        Xpos = x;
        Ypos = y;
    }
}
