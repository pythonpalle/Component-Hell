using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionTowardMouse : MonoBehaviour
{
    private DirectionComponent _directionComponent;

    private void Awake()
    {
        _directionComponent = GetComponent<DirectionComponent>();
    }

    public void SetDirection()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePos - transform.position).normalized;
      
        _directionComponent.Value = direction;
    }
}
