using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaContainer : Container
{
    [SerializeField] private MovementContainer _movementContainer;
    public MovementContainer MovementContainer => _movementContainer;
    
    [SerializeField] private HealthContainer healthContainer;
    public HealthContainer HealthContainer => healthContainer;
}
