using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// [RequireComponent(typeof(SpeedComponent))]
// [RequireComponent(typeof(DamageComponent))]
// [RequireComponent(typeof(SizeComponent))]
// [RequireComponent(typeof(Cooldown))] 
// [RequireComponent(typeof(EffectTimeComponent))] 
public class BaseAttackStats : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpeedComponent speedComponent;
    [SerializeField] private DamageComponent damageComponent;
    [SerializeField] private SizeComponent sizeComponent;
    [SerializeField] private Cooldown cooldownComponent;
    [SerializeField] private EffectTimeComponent effectTimeComponent;

    public SpeedComponent SpeedComponent => speedComponent;
    public DamageComponent DamageComponent => damageComponent;
    public SizeComponent SizeComponent => sizeComponent;
    public Cooldown Cooldown => cooldownComponent;

    public EffectTimeComponent EffectTimeComponent => effectTimeComponent;


    private void Awake()
    {
        //GetComponentReferences();
    }

    void GetComponentReferences()
    {
        speedComponent = GetComponent<SpeedComponent>();
        damageComponent = GetComponent<DamageComponent>();
        sizeComponent = GetComponent<SizeComponent>();
        cooldownComponent = GetComponent<Cooldown>();
        effectTimeComponent = GetComponent<EffectTimeComponent>();
    }

    public void OverrideStats(BaseAttackStats other)
    {
        speedComponent.currentValue = speedComponent.baseValue * other.SpeedComponent.currentValue;
        damageComponent.currentValue = damageComponent.baseValue * other.DamageComponent.currentValue; 
        sizeComponent.currentValue = sizeComponent.baseValue * other.SizeComponent.currentValue;
        cooldownComponent.currentValue = cooldownComponent.baseValue * other.Cooldown.currentValue;
        effectTimeComponent.currentValue = effectTimeComponent.baseValue * other.EffectTimeComponent.currentValue;
    }
}
