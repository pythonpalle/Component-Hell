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
    
    [SerializeField] private bool limitColliderEnterDurations = true;
    [SerializeField] private List<Collider2D> collidersThatHaveTriggered = new List<Collider2D>();
    [SerializeField] private List<float> collidersDurations = new List<float>();
    

    // Collsion
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (limitColliderEnterDurations && collidersThatHaveTriggered.Contains(other.collider))
            return;
        
        OnColEnter?.Invoke(other);
        AddToTriggerList(other.collider);

    }

    private void AddToTriggerList(Collider2D other)
    {
        collidersThatHaveTriggered.Add(other);
        collidersDurations.Add(0);
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
        if (collidersThatHaveTriggered.Contains(other) && limitColliderEnterDurations)
            return;
        
        OnTrigEnter?.Invoke(other);
        AddToTriggerList(other);
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
        for (int i = collidersThatHaveTriggered.Count - 1; i >= 0; i--)
        {
            var collider = collidersThatHaveTriggered[i];
            if (collidersDurations[i] >= timeBetweenEnterChecks)
            {
                collidersThatHaveTriggered.RemoveAt(i);
                collidersDurations.RemoveAt(i);
            }
            else
            {
                collidersDurations[i] += Time.deltaTime;
            }
        }
    }
}
