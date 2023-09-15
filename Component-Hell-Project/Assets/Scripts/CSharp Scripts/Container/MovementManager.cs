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

    public UnityEvent<Vector2> OnUpdateMovement;

    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _dataHolder = Instantiate(_dataHolder);
        }
    }   
    
}
