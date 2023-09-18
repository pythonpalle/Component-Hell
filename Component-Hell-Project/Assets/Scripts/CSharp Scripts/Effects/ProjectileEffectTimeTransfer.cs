using UnityEngine;

public class ProjectileEffectTimeTransfer : MonoBehaviour, IProjectileSpawnListener
{
    private EffectManager _effectManager;

    private void Awake()
    {
        _effectManager = GetComponent<EffectManager>();
    }

    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 _)
    {
        _effectManager.AddMultiplier(data.name, data.effectDuration.Value);
    } 
}