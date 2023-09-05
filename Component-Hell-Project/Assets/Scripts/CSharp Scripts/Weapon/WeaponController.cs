using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent<ProjectileController> OnProjectileFired;
    public UnityEvent<ProjectileController> OnProjectileSpawned;
    
    public ProjectileController projectileController;
    [SerializeField] private float cooldown = 5f;
    // [SerializeField] private int damage = 1;
    // [SerializeField] private Vector2 direction;

    
    private float timeSinceLastFire = int.MinValue;
    
    
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleProjectileFire();
    }

    private void HandleProjectileFire()
    {
        if (Time.time > timeSinceLastFire + cooldown)
        {
            OnProjectileFired?.Invoke(projectileController);
            //var projectileInstance = Instantiate(projectileController, transform.position, Quaternion.identity);
            timeSinceLastFire = Time.time;
        }
    }
}
