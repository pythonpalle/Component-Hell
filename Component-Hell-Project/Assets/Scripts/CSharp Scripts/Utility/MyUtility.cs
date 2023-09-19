using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class MyUtility
{
    public static T TryFindComponentUpwards<T>(Transform trans)
    {
        T comp = trans.GetComponentInChildren<T>();
        
        if (comp != null)
        {
            return comp;
        }

        var parent = trans.parent;
        if (parent)
        {
            return TryFindComponentUpwards<T>(parent);
        }
        else
        {
            return default;
        }
    }
}
