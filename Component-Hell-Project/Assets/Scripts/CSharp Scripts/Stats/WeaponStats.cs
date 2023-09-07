using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedComponent))]
[RequireComponent(typeof(DamageComponent))]
[RequireComponent(typeof(SizeComponent))]
[RequireComponent(typeof(Cooldown))]
public class WeaponStats : MonoBehaviour
{
    
    [Header("Components")]
    [SerializeField] private SpeedComponent speedComponent;
    [SerializeField] private DamageComponent damageComponent;
    [SerializeField] private SizeComponent sizeComponent;
    [SerializeField] private Cooldown cooldown;

    public SpeedComponent SpeedComponent => speedComponent;
    public DamageComponent DamageComponent => damageComponent;
    public SizeComponent SizeComponent => sizeComponent;
    public Cooldown Cooldown => cooldown;

    private void Awake()
    {
        speedComponent = GetComponent<SpeedComponent>();
        damageComponent = GetComponent<DamageComponent>();
        sizeComponent = GetComponent<SizeComponent>();
        cooldown = GetComponent<Cooldown>();
    }

    public void OverrideStats(WeaponStats other)
    {
        // TODO: Fix this. Temporary code to handle a bug where the component references are missing
        if (speedComponent == null)
        {
            Debug.Log("Missing this speed");  
            Debug.Log($"Gameobject: {gameObject.name}"); 
            speedComponent = GetComponent<SpeedComponent>();
            damageComponent = GetComponent<DamageComponent>();
            sizeComponent = GetComponent<SizeComponent>();
            cooldown = GetComponent<Cooldown>();

        }
        
        speedComponent.currentValue = speedComponent.baseValue * other.SpeedComponent.currentValue;
        damageComponent.currentValue = damageComponent.baseValue * other.DamageComponent.currentValue; 
        sizeComponent.currentValue = sizeComponent.baseValue * other.SizeComponent.currentValue;

        cooldown.currentValue = cooldown.baseValue * other.cooldown.currentValue;
    }
}
