using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : MonoBehaviour
{
    [SerializeField] private MovementDataHolder _dataHolder;
    public MovementDataHolder DataHolder => _dataHolder;
    
    [SerializeField] bool instantiateScriptableObjects = true;
    
    void Awake()
    {
        if (instantiateScriptableObjects)
        {
            _dataHolder = Instantiate(_dataHolder);
        }
    }   
}
