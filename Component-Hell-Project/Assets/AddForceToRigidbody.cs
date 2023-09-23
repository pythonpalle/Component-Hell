using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float force = 10;

    public void AddForce()
    {
        if (_rigidbody2D)
        {
            Vector2 awayFromPlayer = ((Vector2)transform.position - PlayerPositionSingleton.Instance.Position).normalized;
            _rigidbody2D.AddForce(awayFromPlayer * force, ForceMode2D.Impulse);
        }
    }
}
