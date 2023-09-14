using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : MonoBehaviour
{
    public UnityEvent<float> OnDamageRecieved;

    public void RecieveDamage(float damage)
    {
        OnDamageRecieved?.Invoke(damage);
    }
}
