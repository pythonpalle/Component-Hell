using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectAdder : MonoBehaviour
{
    [SerializeField] private LayerMask effectedLayers;
    [SerializeField] private EffectComponent effectPrefab;
    [SerializeField] private int childIndex;
    
    private ColliderBroadcaster broadcaster;

    private EffectContainer thisEffectContainer;

    private void Start()
    {
        broadcaster = GetComponentInParent<ColliderBroadcaster>();
        broadcaster.OnTrigEnter.AddListener(AddEffect);

        // hatar detta
        thisEffectContainer = transform.parent.GetComponentInChildren<EffectContainer>(); 
    }

    private void OnDisable()
    {
        broadcaster.OnTrigEnter.RemoveListener(AddEffect);
    }

    private void AddEffect(Collider2D other)
    {
        Debug.Log("Add effect called");
        
        var otherEffectContainer = other.GetComponentInChildren<EffectContainer>();
        if (!otherEffectContainer)
        {
            Debug.Log($"{other.name} has no effect container");
            return;
        }

        if (otherEffectContainer.HasEffect(effectPrefab))
        {
            Debug.Log($"{other.name} already has effect {effectPrefab.name}");
            return;
        }
        var effectInstance = Instantiate(effectPrefab, other.transform);
        effectInstance.OnInstantiated(otherEffectContainer, thisEffectContainer.EffectTime);
        // effectContainer.AddEffect(effectInstance);


        // Debug.Log("Trying to add effect to " + other.name);
        //
        // // Wrong layer
        // if ((effectedLayers.value & (1 << other.gameObject.layer)) > 0 == false)
        // {
        //     Debug.Log("Wrong Layer");
        //     return;
        // }
        //
        // // kan optimeras genom att ett event skickas om en metacontainer träffas, så att alla
        // // effectAdders inte behöver göra denna check
        // var otherMetaContainer = other.GetComponent<MetaContainer>();
        // if (!otherMetaContainer)
        // {
        //     Debug.Log("No meta container found");
        //     return;
        // }
        //
        // var effectContainer = otherMetaContainer.EffectContainer;
        // var effectList = effectContainer.activeEffects;
        //
        // foreach (var effectComp in effectList)
        // {
        //     if (effectComp.GetType() == effectPrefab.GetType())
        //     {
        //         Debug.Log($"{other.name} already has {effectPrefab}");
        //         return;
        //     }
        // }
        //
        // var effect = Instantiate(effectPrefab, other.transform);
        //
        // effect.Setup(otherMetaContainer);
        // effect.OnInstantiated(EffectTime.value);
    }
}
