using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionFromOther : MonoBehaviour
{
    [SerializeField]private DirectionComponent fromDirection;
    [SerializeField]private DirectionComponent toDirection;

    public void SetDirection()
    {
        toDirection.Value = fromDirection.Value == Vector2.zero ? Vector2.right : fromDirection.Value;
    }

}
