using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
    private Vector2Variable directionVariable;
    public Vector2Variable DirectionVariable => directionVariable;
    
    private ObjectMover _objectMover;
    
    public ObjectMover ObjectMover => _objectMover;
    
    private bool instantiateScriptableVariables;
    
    // tODO: ta bort allt ovan

    public MovementDataHolder MovementDataHolder;

   
}
