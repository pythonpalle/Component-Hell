using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private MovementDataHolder _dataHolder;
    public MovementDataHolder DataHolder => _dataHolder;
    
    [SerializeField] bool instantiateScriptableObjects = true;

    [SerializeField] private List<Vector2Listener> directionListeners = new List<Vector2Listener>();
    

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _dataHolder = Instantiate(_dataHolder);
        }
    }

    public void UpdateDirection(Vector2 direction)
    {
        // no need to update movement if direction hasn't changed
        if (direction == _dataHolder.moveDirection)
            return;
        
        foreach (var listener in directionListeners)
        {
            if (listener.enabled)
                listener.OnVector2Change(direction);
        }

        _dataHolder.moveDirection = direction.normalized;
    }
}