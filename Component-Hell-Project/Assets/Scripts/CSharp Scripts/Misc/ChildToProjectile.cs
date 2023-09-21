using UnityEngine;

public class ChildToProjectile : MonoBehaviour
{
    
    private void Start()
    {
        int originalLayer = gameObject.layer;

        // Temporarily change the gameObject's layer to a layer that won't be detected
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        int playerProjectileLayer = LayerMask.GetMask("Player Projectile");

        Collider2D toChildCollider = Physics2D.OverlapCircle(transform.position, 0.001f, playerProjectileLayer);
        
        gameObject.layer = originalLayer;


        if (toChildCollider != null)
        {
            transform.parent = toChildCollider.transform;
        }
        else
        {
        }
    }
}