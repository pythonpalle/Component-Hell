using UnityEngine;

public class ChildToProjectile : MonoBehaviour
{
    
    private void Start()
    {
        // Assuming this script is attached to a projectile object
        // Use Physics2D.OverlapCircle to find the nearest object with the specified layer
        gameObject.layer = 0;
        
        int playerProjectileLayer = LayerMask.GetMask("Player Projectile");

        Collider2D toChildCollider = Physics2D.OverlapCircle(transform.position, 2f, playerProjectileLayer);

        if (toChildCollider != null)
        {
            // Set the parent of the current object (projectile) to the found object
            transform.parent = toChildCollider.transform;
            Debug.Log("Childed to: " + toChildCollider.name);
        }
        else
        {
            Debug.Log("No suitable object found to child to.");
        }
    }
}