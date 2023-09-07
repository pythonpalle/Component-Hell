using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
public class DestroyOnDeath : MonoBehaviour
{
    CharacterHealth health;
    
    void Awake(){
        health = GetComponent<CharacterHealth>();
    }

    private void OnEnable()
    {
        health.OnDeath.AddListener(Destroy);
    }
    
    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Destroy);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
