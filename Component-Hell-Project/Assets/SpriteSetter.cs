using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    
    // Start is called before the first frame update
    public void SetSprite(MonoBehaviour behaviour)
    {
        behaviour.GetComponent<SpriteRenderer>().sprite = _sprite;
    }
}
