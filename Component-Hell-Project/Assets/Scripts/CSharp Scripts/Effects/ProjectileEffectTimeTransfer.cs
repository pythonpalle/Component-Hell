using UnityEngine;

public class ProjectileEffectTimeTransfer : MonoBehaviour, IProjectileSpawnListener
{
    private EffectContainer _effectContainer;

    private void Awake()
    {
        _effectContainer = GetComponent<EffectContainer>();
    }

    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 _)
    {
        _effectContainer.AddMultiplier(data.name, data.effectDuration.Value);
    } 
}