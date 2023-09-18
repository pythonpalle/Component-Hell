using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectAdder : MonoBehaviour
{
    [SerializeField] private EffectComponent effectPrefab;
    
    private ColliderBroadcaster broadcaster;
    private DynamicFloat effectTime;

    private void Start()
    {
        // Finds broadcaster in order for recieving collision events to know when to potentially add the effect
        broadcaster = GetComponentInParent<ColliderBroadcaster>();
        broadcaster.OnTrigEnter.AddListener(AddEffect);

        // hatar detta
        // gets effect time from the effect container 
        effectTime = transform.parent.GetComponentInChildren<EffectContainer>().EffectTime; 
    }

    private void OnDisable()
    {
        broadcaster.OnTrigEnter.RemoveListener(AddEffect);
    }

    private void AddEffect(Collider2D other)
    {
        var otherEffectContainer = other.GetComponentInChildren<EffectContainer>();
        if (!otherEffectContainer)
            return;

        if (otherEffectContainer.HasEffect(effectPrefab))
            return;
        
        var effectInstance = Instantiate(effectPrefab, other.transform);
        effectInstance.OnInstantiated(otherEffectContainer, effectTime);
    }
}
