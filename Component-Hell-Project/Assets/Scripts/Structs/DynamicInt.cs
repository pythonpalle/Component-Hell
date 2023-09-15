using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DynamicInt
{
    [SerializeField] private int value;
    public int Value => value;
    
    [NonSerialized] private List<DynamicInt> adders;


    public void AddAdder(DynamicInt mult)
    {
        if (adders == null)
        {
            adders = new List<DynamicInt>();
        }

        if (!adders.Contains(mult))
        {
            adders.Add(mult);
            value += mult.value;
        }
    }
    
    public void RemoveMultiplier(DynamicInt adder)
    {
        if (adders == null)
        {
            adders = new List<DynamicInt>();
        }

        if (adders.Contains(adder))
        {
            adders.Remove(adder);
            value -= adder.value;
        }
    }
}
