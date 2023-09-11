using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
    public static T TryFindComponentUpwards<T>(Transform trans)
    {
        T comp = trans.GetComponent<T>();
        
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
