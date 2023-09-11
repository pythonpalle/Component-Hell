using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    protected MetaContainer MetaContainer;
    void Awake()
    {
        MetaContainer = MyUtility.TryFindComponentUpwards<MetaContainer>(transform);
    }
}
