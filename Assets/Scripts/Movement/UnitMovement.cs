using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public class MoveTask
    {
        public Unit Target;
        public Vector3 ToPosition;
        public float Speed;

        public MoveTask(Unit target, Vector3 toPosition, float speed)
        {
            Target = target;
            ToPosition = toPosition;
            Speed = speed;
        }
    }

    private List<MoveTask> _tasks = new List<MoveTask>(); 

    public void AddTask(Unit target, Vector3 position, float speed)
    {
        if (target == null)
            return;
        //if we already have task with the same target, we have to replace task
        for (int i = 0; i < _tasks.Count; i++)
        {
            if(ReferenceEquals(_tasks[i].Target, target))
            {
                _tasks[i] = new(target, position, speed);
            }
        }

        _tasks.Add(new MoveTask(target, position, speed));
    }

    void Update()
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            var target = _tasks[i].Target.GetComponent<Transform>();
            var finalPos = _tasks[i].ToPosition;
            target.position = Vector3.MoveTowards
                (target.position, finalPos, _tasks[i].Speed);

            _tasks[i].Target.GetAnimator().SetBool("isMoving", true);
            if (target.position == finalPos)
            {
                _tasks[i].Target.GetAnimator().SetBool("isMoving", false);
                _tasks.RemoveAt(i);
                i--;
            }
        }
    }
}
