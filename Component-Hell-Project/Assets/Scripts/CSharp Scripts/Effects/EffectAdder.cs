using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAdder : MonoBehaviour
{

    public LayerMask effectedLayers;
    public EffectComponent effectPrefab;

    private void OnEnable()
    {
        Collider collider = GetComponentInParent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.layer & effectedLayers) != other.gameObject.layer)
        {
            Debug.Log("Wrong layer");
            return;
        }

        if (other.GetComponentInChildren(Type.GetType(effectPrefab.name)))
        {
            Debug.Log($"{other.name} already has a {effectPrefab.name} attached.");
            return;    
        }

        Instantiate(effectPrefab, other.transform);
    }
}
