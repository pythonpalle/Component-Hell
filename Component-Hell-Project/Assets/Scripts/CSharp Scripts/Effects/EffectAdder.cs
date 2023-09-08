using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAdder : MonoBehaviour
{

    public LayerMask effectedLayers;
    public EffectComponent effectPrefab;

    private ColliderBroadcaster broadcaster;

    private void OnEnable()
    {
        broadcaster = GetComponentInParent<ColliderBroadcaster>();
        broadcaster.OnTrigEnter.AddListener(AddEffect);
    }

    private void OnDisable()
    {
        broadcaster.OnTrigEnter.RemoveListener(AddEffect);
    }

    private void AddEffect(Collider2D other)
    {
        if ((effectedLayers.value & (1 << other.gameObject.layer)) > 0 == false)
        {
            Debug.Log("Wrong layer");
            return;
        }

        // if (other.GetComponentInChildren(Type.GetType(effectPrefab.name)))
        // {
        //     Debug.Log($"{other.name} already has a {effectPrefab.name} attached.");
        //     return;    
        // }
        //
        // Instantiate(effectPrefab, other.transform);
        // broadcaster.OnTrigEnter.RemoveListener(AddEffect);
    }
}
