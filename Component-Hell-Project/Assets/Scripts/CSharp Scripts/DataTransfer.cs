using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataTransfer : GameComponent
{
    [SerializeField] private bool multiply;

    protected float Multiplier(float value) => multiply ? value : 1;
    
    public abstract void Transfer(GameComponent toComponent);
}
