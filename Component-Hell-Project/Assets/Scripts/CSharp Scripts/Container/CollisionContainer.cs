using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionContainer : Container
{
    [SerializeField] private ColliderBroadcaster _colliderBroadcaster;
    public ColliderBroadcaster ColliderBroadcaster => _colliderBroadcaster;
}
