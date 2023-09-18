using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : MonoBehaviour
{
    public UnityEvent<float> OnDamageRecieved;

    // [SerializeField] private bool recieveFixedAmountOfDamge;
    // [SerializeField] private float fixedDamage = 1;

    public void RecieveDamage(float damage)
    {
        // if (recieveFixedAmountOfDamge)
        //     damage = fixedDamage;
        
        OnDamageRecieved?.Invoke(damage);
    }
}
