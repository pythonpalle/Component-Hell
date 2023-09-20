using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeSpriteColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool findSpriteRenderer;
    private Color baseColor;

    [SerializeField] private Color changeColor;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (findSpriteRenderer && !spriteRenderer) 
            FindSpriteRenderer();
    }

    private void FindSpriteRenderer()
    {
        spriteRenderer = MyUtility.TryFindComponentUpwards<SpriteRenderer>(transform);
        if (spriteRenderer)
        {
            baseColor = spriteRenderer.color;
        }
    }

    public void SetNewColor()
    {
        if (spriteRenderer)
        {
            spriteRenderer.color = changeColor;
            Debug.Log("Setting new sprite color!");
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
