using System.Collections;
using UnityEngine;

public class MoveToCommand : ICommand
{
    Transform _transform;
    private Vector3 _position;

    public MoveToCommand(Transform fromTransform, Vector3 toPos)
    {
        _transform = fromTransform;
        _position = toPos;
    }

    public void Execute()
    {
        while (_transform.position != _position)
        {
            _transform.position = _position;
        }
    }
}
