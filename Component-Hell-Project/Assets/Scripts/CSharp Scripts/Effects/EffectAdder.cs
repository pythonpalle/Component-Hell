using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAdder : MonoBehaviour
{

    [SerializeField] private LayerMask effectedLayers;
    [SerializeField] private EffectComponent effectPrefab;
    
    private EffectTimeComponent EffectTime;
    private ColliderBroadcaster broadcaster;

    private void OnEnable()
    {
        EffectTime = transform.parent.GetComponentInChildren<EffectTimeComponent>();
        
        broadcaster = GetComponentInParent<ColliderBroadcaster>();
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
        
        // kan behöva fixas senare: behöver inte vara samma effekt komponent som hittas
        var effectComponents = other.GetComponentsInChildren<EffectComponent>();
        if (effectComponents != null)
        {
            foreach (var component in effectComponents)
            {
                string componentName = component.name;
                string prefabName = effectPrefab.name;

                bool containsComponent = componentName.Contains(prefabName);
                
                // Debug.Log("Added prefab name: " + effectPrefab.name);
                // Debug.Log("Found component name: " + component.name);
                
                if (containsComponent)
                {
                    //Debug.Log($"{other.name} already has a {effectPrefab.name} attached.");
                    return;   
                }
            }
            
            
           
            
            
            
              
        }
        
        var effect = Instantiate(effectPrefab, other.transform);
        effect.duration = EffectTime.currentValue;
    }
}
