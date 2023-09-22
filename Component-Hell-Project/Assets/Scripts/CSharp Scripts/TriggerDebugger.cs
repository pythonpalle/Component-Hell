using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDebugger : MonoBehaviour
{
    public void OnTrig(Collider2D other)
    {
        if (other.gameObject.layer.ToString() != "Player")
        {
            Debug.Log("Collider: " + other.name);
        }
    }
}
