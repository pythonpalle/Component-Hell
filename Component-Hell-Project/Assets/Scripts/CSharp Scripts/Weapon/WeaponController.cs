using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private ProjectileController projectileController;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private Vector2 direction;

    
    private float timeSinceLastFire;
    
    
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
            var projectileInstance = Instantiate(projectileController);
            timeSinceLastFire = Time.time;
        }
    }
}
