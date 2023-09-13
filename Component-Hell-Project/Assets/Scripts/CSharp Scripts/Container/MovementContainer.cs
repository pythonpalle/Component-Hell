using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
   [Header("Direction")]
    [SerializeField] private Vector2Variable directionVariable;
    public Vector2Variable DirectionVariable => directionVariable;

    [SerializeField] private ObjectMover _objectMover;

    public ObjectMover ObjectMover => _objectMover;

    [SerializeField] private bool instantiateScriptableVariables;

    private void Awake()
    {
        if (instantiateScriptableVariables)
        {
            directionVariable = Instantiate(directionVariable);
        }

        _objectMover = GetComponent<ObjectMover>();
    }
}
