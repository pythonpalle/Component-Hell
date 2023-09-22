using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindLatestTriggeredCollider : MonoBehaviour
{
    public Collider2D Latest;

    public UnityEvent<Collider2D> OnStoreLatest;

    public void StoreLatest(Collider2D other)
    {
        Latest = other;
    }
}
