using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ColliderBroadcaster : MonoBehaviour
{
    private Collider _collider;

    public UnityEvent<Collision2D> OnColEnter;
    [HideInInspector] public UnityEvent<Collision2D> OnColExit;
    public UnityEvent<Collision2D> OnColStay;
    
    public UnityEvent<Collider2D> OnTrigEnter;
    [HideInInspector] public UnityEvent<Collider2D> OnTrigExit;
    [HideInInspector] public UnityEvent<Collider2D> OnTrigStay;
        
    void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    // Collsion
    public void OnCollisionEnter2D(Collision2D other)
    {
        OnColEnter?.Invoke(other);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        OnColExit?.Invoke(other);
    }
    
    public void OnCollisionStay2D(Collision2D other)
    {
        OnColStay?.Invoke(other);
    }
    
    
    // Trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigEnter?.Invoke(other);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        OnTrigExit?.Invoke(other);
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        OnTrigStay?.Invoke(other);
    }
}
