using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEffect : EffectComponent
{
    [SerializeField] private float knockBackForce = 10;
    
    private Rigidbody2D rigidbody2D;
    private MovementDataHolder movementDataHolder;
    
    protected override void Activate()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = MyUtility.TryFindComponentUpwards<Rigidbody2D>(transform);
        }
        
        if (!movementDataHolder)
        {
            movementDataHolder = MyUtility.TryFindComponentUpwards<MovementManager>(transform).DataHolder;
        }

        if (rigidbody2D && movementDataHolder)
        {
            Vector2 awayFromPlayer =
                ((Vector2)transform.position - PlayerMovementSingleton.Instance.Position).normalized;
            rigidbody2D.AddForce(awayFromPlayer * knockBackForce, ForceMode2D.Impulse);
        }
    }

    protected override void Deactivate()
    {
        if (rigidbody2D )
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
