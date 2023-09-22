using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeSpriteColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color baseColor;
    [SerializeField] private Color changeColor;
    
    public void SetNewColor()
    {
        if (spriteRenderer)
        {
            spriteRenderer.color = changeColor;
        }
    }

    public void ResetColor()
    {
        if (spriteRenderer)
        {
            spriteRenderer.color = baseColor;
        }
    }
}
