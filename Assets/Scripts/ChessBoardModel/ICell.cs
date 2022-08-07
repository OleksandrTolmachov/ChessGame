public interface ICell
{
    bool IsOccupied { get; }

    void Deoccupy();
    void Deselect();
    void Occupy(Unit unit);
    void Select();
}