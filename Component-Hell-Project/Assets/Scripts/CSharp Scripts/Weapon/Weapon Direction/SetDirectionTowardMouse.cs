using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionTowardMouse : MonoBehaviour
{
    public void SetDirection(MovementDataHolder moveData) 
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePos - transform.position).normalized; 
      
        moveData.moveDirection = direction;
    } 
}
