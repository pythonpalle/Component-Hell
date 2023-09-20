using UnityEngine;

public class ChildToProjectile : MonoBehaviour
{
    
    private void Start()
    {
        // Assuming this script is attached to a projectile object
        // Use Physics2D.OverlapCircle to find the nearest object with the specified layer
        // Store the original layer of this gameObject
        int originalLayer = gameObject.layer;

        // Temporarily change the gameObject's layer to a layer that won't be detected
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        int playerProjectileLayer = LayerMask.GetMask("Player Projectile");

        Collider2D toChildCollider = Physics2D.OverlapCircle(transform.position, 0.001f, playerProjectileLayer);
        
        gameObject.layer = originalLayer;


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