using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
    public MovementDataHolder DataHolder;
    [SerializeField] bool instanitateMovementData = true;
    
    void Awake()
    {
        if (instanitateMovementData)
        {
            DataHolder = Instantiate(DataHolder);
        }
    }   
}
