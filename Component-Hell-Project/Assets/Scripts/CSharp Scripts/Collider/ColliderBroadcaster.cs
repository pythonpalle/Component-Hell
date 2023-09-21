using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class ColliderBroadcaster : MonoBehaviour
{
    public UnityEvent<Collision2D> OnColEnter;
    [HideInInspector] public UnityEvent<Collision2D> OnColExit;
    public UnityEvent<Collision2D> OnColStay;
    
    public UnityEvent<Collider2D> OnTrigEnter;
    [HideInInspector] public UnityEvent<Collider2D> OnTrigExit;
    [HideInInspector] public UnityEvent<Collider2D> OnTrigStay;
    
    [SerializeField] private float timeBetweenEnterChecks = 2;

    private Dictionary <Collider2D, float> triggerEnterers = new Dictionary <Collider2D, float>();
    private List <Collider2D> triggerEnterersToRemove = new List <Collider2D>();
    

    // Collsion
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (triggerEnterers.ContainsKey(other.collider))
            return;
        
        OnColEnter?.Invoke(other);
        triggerEnterers.Add(other.collider, 0);
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
        if (triggerEnterers.ContainsKey(other))
            return;
        
        OnTrigEnter?.Invoke(other);
        triggerEnterers.Add(other, 0);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        OnTrigExit?.Invoke(other);
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        OnTrigStay?.Invoke(other);
    }
    
    private void Update()
    {
        HandleTriggerEnterers();
    }

    private void HandleTriggerEnterers()
    {
        foreach (var collider in triggerEnterers)
        {
            if (collider.Value >= timeBetweenEnterChecks)
            {
                triggerEnterersToRemove.Add(collider.Key);
            }
            else
            {
                triggerEnterers[collider.Key] += Time.deltaTime;
            }
        }

        for (int i = triggerEnterersToRemove.Count - 1; i >= 0; i--)
        {
            triggerEnterers.Remove(triggerEnterersToRemove[i]);
            triggerEnterersToRemove.RemoveAt(i);
        }
        
    }
}
