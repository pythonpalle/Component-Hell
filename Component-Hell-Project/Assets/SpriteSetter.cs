using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetter : MonoBehaviour, WeaponDataUpdateListener
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update 
    public void SetSprite(Sprite _sprite)
    {
        _spriteRenderer.sprite = _sprite;
    }

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        SetSprite(data.sprite);
    }
}
