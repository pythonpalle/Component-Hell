using UnityEngine;

public class EffectAdder : MonoBehaviour
{
    [SerializeField] private EffectComponent effectPrefab;
    public EffectComponent EffectToAdd => effectPrefab;
    
    
    public void AddEffect(EffectManager otherEffectManager, DynamicFloat effectTime)
    {
        var effectInstance = Instantiate(effectPrefab, otherEffectManager.transform);
        effectInstance.OnInstantiated(otherEffectManager, effectTime);
    }
}
