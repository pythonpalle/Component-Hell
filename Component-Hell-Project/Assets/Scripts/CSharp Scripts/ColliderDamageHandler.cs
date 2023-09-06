using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamageHandler : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private bool damagePlayer;
    [SerializeField] private bool damageEnemy;

    public void HandleDamage(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterHealth health))
        {
            if (other.gameObject.CompareTag("Player") && damagePlayer
                || other.gameObject.CompareTag("Enemy") && damageEnemy)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
