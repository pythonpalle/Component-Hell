using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataTransfer : GameComponent
{
    public abstract void Transfer(GameComponent toComponent);
}
