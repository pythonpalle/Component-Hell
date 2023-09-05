using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float timeTilDespawn = 5f;
    private float timeOfSpawn;
    
    private void OnEnable()
    {
        timeOfSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOfSpawn + timeTilDespawn)
        {
            Destroy(gameObject);
        }
    }
}
