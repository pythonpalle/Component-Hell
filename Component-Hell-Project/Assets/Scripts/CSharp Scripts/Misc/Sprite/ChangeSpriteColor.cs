using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeSpriteColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color baseColor;
    [SerializeField] private Color changeColor;
    [SerializeField] private bool changeBack;
    
    public void SetNewColor()
    {
        if (spriteRenderer)
        {
            spriteRenderer.color = changeColor;

            if (changeBack)
            {
                Invoke("ResetColor", 0.2f);
            }
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
