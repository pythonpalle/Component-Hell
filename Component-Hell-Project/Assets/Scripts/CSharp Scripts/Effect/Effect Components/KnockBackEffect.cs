using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEffect : EffectComponent
{
    [SerializeField] private float knockBackForce = 10;
    
    private Rigidbody2D rigidbody2D;
    private MovementDataHolder movementDataHolder;
    private float timeOfKnockback;
    private bool hasKnockedBack;
    
    protected override void Activate()
    {
        if (Time.time < timeOfKnockback + 0.2f)
        {
            return;
        }
        
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
            timeOfKnockback = Time.time;
            hasKnockedBack = true;
            //
            // if (gameObject.activeSelf)
            //     StartCoroutine(StopForce(0.2f));
        }
    }

    private IEnumerator StopForce(float f)
    {
        if (!gameObject.activeSelf) 
            yield return null;
        
        yield return new WaitForSeconds(f);
        Deactivate();
    }

    private void OnDisable()
    {
        Deactivate();
    }

    protected override void Deactivate()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = MyUtility.TryFindComponentUpwards<Rigidbody2D>(transform);
        }
        
        if (rigidbody2D )
        {
            rigidbody2D.velocity = Vector2.zero;
            hasKnockedBack = false;
        }
    }

    private void Update()
    {
        // if (!hasKnockedBack)
        //     return;
        
        if (Time.time > timeOfKnockback + 0.2f)
        {
            Deactivate();
        }
    }
}
