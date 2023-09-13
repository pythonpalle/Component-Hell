using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatValueWrapper))]
public class Container : MonoBehaviour
{
    [SerializeField] protected FloatValueWrapper valueWrapper;
    public FloatValueWrapper ValueWrapper => valueWrapper;
}
