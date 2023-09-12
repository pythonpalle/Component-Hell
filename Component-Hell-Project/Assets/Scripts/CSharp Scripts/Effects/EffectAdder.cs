using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAdder : GameComponent
{

    [SerializeField] private LayerMask effectedLayers;
    [SerializeField] private EffectComponent effectPrefab;
    
    private FloatVariable EffectTime;
    private ColliderBroadcaster broadcaster;


    public override void Setup(MetaContainer container)
    {
        base.Setup(container);
        
        EffectTime = _metaContainer.EffectContainer.EffectTimeVariable;

        broadcaster = _metaContainer.CollisionContainer.ColliderBroadcaster;
        broadcaster.OnTrigEnter.AddListener(AddEffect);
    }

    private void OnDisable()
    {
        broadcaster.OnTrigEnter.RemoveListener(AddEffect);
    }

    private void AddEffect(Collider2D other)
    {
        // Wrong layer
        if ((effectedLayers.value & (1 << other.gameObject.layer)) > 0 == false)
        {
            return;
        }

        // kan optimeras genom att ett event skickas om en metacontainer träffas, så att alla
        // effectAdders inte behöver göra denna check
        var otherMetaContainer = other.GetComponent<MetaContainer>();
        if (!otherMetaContainer)
        {
            Debug.Log("No meta container found");
            return;
        }

        var effectContainer = otherMetaContainer.EffectContainer;
        var effectList = effectContainer.activeEffects;

        foreach (var effectComp in effectList)
        {
            if (effectComp.GetType() == effectPrefab.GetType())
            {
                Debug.Log($"{other.name} already has {effectPrefab}");
                return;
            }
        }

        var effect = Instantiate(effectPrefab, other.transform);

        effect.Setup(otherMetaContainer);
        effect.OnInstantiated(EffectTime.value);
    }
}
