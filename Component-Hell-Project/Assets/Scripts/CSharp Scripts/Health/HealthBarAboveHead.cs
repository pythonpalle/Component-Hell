using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealth))]
[RequireComponent(typeof(SpriteRenderer))]
public class HealthBarAboveHead : MonoBehaviour
{
    [SerializeField] private Sprite healthBarSprite;

    private CharacterHealth characterHealth;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        characterHealth = GetComponent<CharacterHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
