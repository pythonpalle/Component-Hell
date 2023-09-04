using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeTest : MonoBehaviour
{
    public CharacterHealth health;
    
    
    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.TakeDamage(20);
        }
    }
}
