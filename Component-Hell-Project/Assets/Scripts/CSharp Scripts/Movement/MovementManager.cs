using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectMover))]
public class MovementManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private MovementDataHolder _dataHolder;
    [SerializeField] private MovementControllerBase moveController;
    public MovementDataHolder DataHolder => _dataHolder;
    private DynamicFloat moveSpeed;
    
    [SerializeField] bool instantiateScriptableObjects = true;

    [Header("Target")] 
    [SerializeField] [Tooltip("Target that this is moving towards, if any.")]
    private Transform targetTransform;
    
    [Header("Components")] 
    [SerializeField] private ObjectMover objectMover;
    
    [Header("Listeners")]
    [SerializeField] private List<Vector2Listener> directionListeners = new List<Vector2Listener>();
    

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _dataHolder = Instantiate(_dataHolder);
        }

        SetMoveController(moveController);
        moveSpeed = _dataHolder.moveSpeed;
        objectMover = GetComponent<ObjectMover>();
    }

    public void SetMoveController(MovementControllerBase controllerToSet)
    {
        moveController = instantiateScriptableObjects ? Instantiate(controllerToSet) : controllerToSet;
    }

    private void Update()
    {
        HandleUpdateMovement();
    }

    private void HandleUpdateMovement()
    {
        if (moveController)
        {
            var newDirection = moveController.GetNextDirection(this);
            UpdateDirection(newDirection);
        }
        objectMover.Move(_dataHolder.moveDirection, moveSpeed.Value);
    }

    private void UpdateDirection(Vector2 direction)
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

    public void SetTargetTransform(Transform other)
    {
        targetTransform = other;
    }

    public Vector2 GetDirection()
    {
        return _dataHolder.moveDirection;
    }

    public Transform GetTarget()
    {
        return targetTransform;
    }

    public MovementControllerBase GetController()
    {
        return moveController;
    }
}