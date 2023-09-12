using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionTowardMouse : GameComponent
{
    private Vector2Variable directionVariable;

    private void Start()
    {
        directionVariable = _metaContainer.MovementContainer.DirectionVariable;
    }

    public void SetDirection()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePos - transform.position).normalized;
      
        directionVariable.value = direction;
    }
}
