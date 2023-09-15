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

    [SerializeReference] private List<IMovementListener> _movementListeners;

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _dataHolder = Instantiate(_dataHolder);
        }
    }

    public void UpdateMovement(Vector2 direction)
    {
        // no need to update movement if direction hasn't changed
        if (direction == _dataHolder.moveDirection)
            return;
        
        foreach (var listener in _movementListeners)
        {
            listener.OnMovementChange(direction);
        }

        _dataHolder.moveDirection = direction.normalized;
    }
}


public interface IMovementListener
{
    public void OnMovementChange(Vector2 direction);
}
