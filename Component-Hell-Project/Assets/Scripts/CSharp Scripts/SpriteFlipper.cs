using System;
using UnityEngine;

public class SpriteFlipper : Vector2Listener
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool conditionToFlipLeftAndRight;
    
    Func<float, float, bool> compareFunction;

    private void Start()
    {
        SetCompareFunction();
    }
    

    public override void OnVector2Change(Vector2 direction)
    {
        if ( direction.x == 0)
            return;
        
        spriteRenderer.flipX = compareFunction(direction.x, 0); 
    }

    private void SetCompareFunction()
    {
        if (conditionToFlipLeftAndRight)
        {
            compareFunction = (a, b) => a > b;
        }
        else
        {
            compareFunction = (a, b) => a < b;
        }
    }
}