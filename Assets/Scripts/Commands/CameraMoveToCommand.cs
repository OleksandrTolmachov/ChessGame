using System.Collections;
using UnityEngine;

public class CameraMoveToCommand : ICommand
{
    private Vector3 _position;

    public CameraMoveToCommand(Vector3 position)
    {
        _position = position;
    }

    public void Execute()
    {
        var camPos = Camera.main.transform;
        while (Camera.main.transform.position != _position)
        {
            camPos.position = Vector3.Lerp(camPos.position, _position, 0.0006f);
        }
    }
}
