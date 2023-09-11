using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
    [SerializeField] private DirectionComponent directionComponent;
    public DirectionComponent DirectionComponent => directionComponent;
    
    [SerializeField] private SpeedComponent speedComponent;
    public SpeedComponent SpeedComponent => speedComponent;
}
