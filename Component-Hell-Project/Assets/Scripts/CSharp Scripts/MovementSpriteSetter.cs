using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpriteSetter : MonoBehaviour 
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sprite0;
    [SerializeField] private Sprite sprite1;
    
    [SerializeField] private float timeBetweenShifts;
    private float timeOfLastShift;
    private bool hasShifted;
    

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (Time.time > timeOfLastShift + timeBetweenShifts)
        {
            Shift();
            timeOfLastShift = Time.time;
        }
    }

    private void Shift()
    {
        spriteRenderer.sprite = hasShifted ? sprite0 : sprite1;
        hasShifted = !hasShifted;
    }
}