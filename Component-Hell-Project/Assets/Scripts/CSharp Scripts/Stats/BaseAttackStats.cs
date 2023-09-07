using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(SpeedComponent))]
[RequireComponent(typeof(DamageComponent))]
[RequireComponent(typeof(SizeComponent))]
[RequireComponent(typeof(Cooldown))] 
public class BaseAttackStats : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpeedComponent speedComponent;
    [SerializeField] private DamageComponent damageComponent;
    [SerializeField] private SizeComponent sizeComponent;
    [SerializeField] private Cooldown cooldownComponent;

    public SpeedComponent SpeedComponent => speedComponent;
    public DamageComponent DamageComponent => damageComponent;
    public SizeComponent SizeComponent => sizeComponent;
    public Cooldown Cooldown => cooldownComponent;


    private void Awake()
    {
        GetComponentReferences();
    }

    void GetComponentReferences()
    {
        speedComponent = GetComponent<SpeedComponent>();
        damageComponent = GetComponent<DamageComponent>();
        sizeComponent = GetComponent<SizeComponent>();
        cooldownComponent = GetComponent<Cooldown>();
    }

    public void OverrideStats(BaseAttackStats other)
    {
        // TODO: Fix this. Temporary code to handle a bug where the component references are missing
        if (speedComponent == null)
        {
            Debug.Log("Missing this speed");  
            Debug.Log($"Gameobject: {gameObject.name}"); 
            GetComponentReferences();
        }
        
        speedComponent.currentValue = speedComponent.baseValue * other.SpeedComponent.currentValue;
        damageComponent.currentValue = damageComponent.baseValue * other.DamageComponent.currentValue; 
        sizeComponent.currentValue = sizeComponent.baseValue * other.SizeComponent.currentValue;
        cooldownComponent.currentValue = cooldownComponent.baseValue * other.Cooldown.currentValue;
    }
}
